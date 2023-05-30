<template>
    <el-dialog
        v-model="visible"
        :title="titleMap[mode]"
        :width="800"
        destroy-on-close
        @closed="$emit('closed')"
    >
        <el-form
            ref="dialogForm"
            :disabled="mode === 'view'"
            :model="form"
            :rules="rules"
            label-position="right"
            label-width="100px"
        >
            <el-tabs tab-position="top">
                <el-tab-pane label="基本信息">
                    <el-form-item label="头像" prop="avatar">
                        <sc-upload
                            v-model="form.avatar"
                            title="上传头像"
                        ></sc-upload>
                    </el-form-item>
                    <el-form-item label="用户名" prop="sysUser.userName">
                        <el-input
                            v-model="form.sysUser.userName"
                            clearable
                            placeholder="用户名"
                        ></el-input>
                    </el-form-item>
                    <el-form-item label="登录密码" prop="sysUser.passwordText">
                        <el-input
                            v-model="form.sysUser.passwordText"
                            clearable
                            placeholder="登录密码"
                        ></el-input>
                    </el-form-item>
                    <el-form-item label="手机号" prop="sysUser.mobile">
                        <el-input
                            v-model="form.sysUser.mobile"
                            clearable
                            placeholder="手机号"
                        ></el-input>
                    </el-form-item>
                    <el-form-item
                        v-if="mode !== 'add'"
                        label="余额"
                        prop="balance"
                    >
                        <el-input
                            v-model="form.balance"
                            clearable
                            disabled
                        ></el-input>
                    </el-form-item>
                    <template v-if="mode !== 'add'">
                        <el-form-item label="启用" prop="enabled">
                            <el-switch v-model="form.enabled"></el-switch>
                        </el-form-item>
                    </template>
                </el-tab-pane>
                <el-tab-pane v-if="mode === 'view'" label="Json">
                    <json-viewer
                        :expand-cateh="5"
                        :expanded="true"
                        :value="form"
                        boxed
                        copyable
                        sort
                    ></json-viewer>
                </el-tab-pane>
            </el-tabs>
        </el-form>
        <template #footer>
            <el-button @click="visible = false">取 消</el-button>
            <el-button
                v-if="mode !== 'view'"
                :loading="isSaving"
                type="primary"
                @click="submit()"
                >保 存
            </el-button>
        </template>
    </el-dialog>
</template>

<script>
import JsonViewer from "vue-json-viewer";
import { v4 as uuidv4 } from "uuid";

export default {
    components: {
        JsonViewer,
    },
    emits: ["success", "closed"],
    data() {
        return {
            mode: "add",
            titleMap: {
                view: "查看会员",
                add: "新增会员",
                edit: "编辑会员",
            },
            visible: false,
            isSaving: false,
            //表单数据
            form: {
                sysUser: {
                    roleIds: [0],
                    positionIds: [0],
                    passwordText: "1234qwer",
                    profile: {},
                    userName:
                        this.$CONFIG.STRINGS.FLG_SYSTEM_PREFIX +
                        uuidv4().substring(24),
                    avatar: "",
                    mobile: "",
                },
                id: 0,
                balance: 0,
            },
            //验证规则
            rules: {
                sysUser: {
                    userName: [
                        {
                            required: true,
                            pattern: this.$CONFIG.STRINGS.RGX_USERNAME,
                            message: "4位以上字母、数字或下划线",
                        },
                        {
                            validator: async (rule, valueEquals, callback) => {
                                try {
                                    const res = await this.$API[
                                        "sys_user"
                                    ].checkUserNameAvailable.post({
                                        userName: valueEquals,
                                        id: this.form.sysUser.id,
                                    });
                                    return res.data
                                        ? callback()
                                        : callback(new Error("用户名已被使用"));
                                } catch {}
                            },
                            trigger: "blur",
                        },
                    ],
                    passwordText: [
                        {
                            required: true,
                            pattern: this.$CONFIG.STRINGS.RGX_PASSWORD,
                            message: "8位以上数字字母组合",
                        },
                    ],
                    mobile: [
                        {
                            required: true,
                            pattern: this.$CONFIG.STRINGS.RGX_MOBILE,
                            message: "请输入手机号",
                        },
                        {
                            validator: async (rule, valueEquals, callback) => {
                                try {
                                    const res = await this.$API[
                                        "sys_user"
                                    ].checkMobileAvailable.post({
                                        mobile: valueEquals,
                                        id: this.form.sysUser.id,
                                    });
                                    return res.data
                                        ? callback()
                                        : callback(new Error("手机号已被使用"));
                                } catch {}
                            },
                            trigger: "blur",
                        },
                    ],
                },
            },
        };
    },
    mounted() {},
    methods: {
        //显示
        open(mode = "add") {
            this.mode = mode;
            this.visible = true;
            return this;
        },
        //表单提交方法
        submit() {
            this.$refs.dialogForm.validate(async (valid) => {
                if (valid) {
                    this.isSaving = true;
                    const reqData = JSON.parse(JSON.stringify(this.form));
                    try {
                        const method =
                            this.mode === "add"
                                ? this.$API["biz_member"].create
                                : this.$API["biz_member"].update;
                        const res = await method.post(reqData);
                        this.$emit("success", res.data, this.mode);
                        this.visible = false;
                        this.$message.success("操作成功");
                    } catch {}
                    this.isSaving = false;
                } else {
                    return false;
                }
            });
        },
        //表单注入数据
        async setData(data) {
            //可以和上面一样单个注入，也可以像下面一样直接合并进去
            Object.assign(this.form, data);

            const [res1, res2] = await Promise.all([
                this.$API["sys_user"].query.post({
                    filter: {
                        id: this.form.sysUser.id,
                    },
                }),

                this.$API["sys_user"].queryProfile.post({
                    dynamicFilter: {
                        field: "id",
                        operator: "eq",
                        value: this.form.sysUser.id,
                    },
                }),
            ]);
            Object.assign(this.form.sysUser, {
                ...res1.data[0],
                profile: res2.data[0],
            });

            this.form.sysUser.roleIds = this.form.sysUser.roles.map(
                (x) => x.id
            );
            this.form.sysUser.positionIds = this.form.sysUser.positions.map(
                (x) => x.id
            );

            console.log(this.form.sysUser);
        },
    },
};
</script>

<style></style>