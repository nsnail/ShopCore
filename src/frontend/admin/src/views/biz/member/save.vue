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
                    <el-form-item label="用户名" prop="userName">
                        <el-input
                            v-model="form.userName"
                            clearable
                            placeholder="用户名"
                        ></el-input>
                    </el-form-item>
                    <el-form-item label="手机号" prop="mobile">
                        <el-input
                            v-model="form.mobile"
                            clearable
                            placeholder="手机号"
                        ></el-input>
                    </el-form-item>
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
                avatar: "",
                userName: "sdf",
                mobile: "",
            },
            //验证规则
            rules: {
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
                                    "biz_member"
                                ].checkMemberUserNameAvailable.post({
                                    userName: valueEquals,
                                });
                                return res.data
                                    ? callback()
                                    : callback(new Error("用户名已被使用"));
                            } catch {}
                        },
                        trigger: "blur",
                    },
                ],
                mobile: [
                    {
                        required: true,
                        pattern: this.$CONFIG.STRINGS.RGX_MOBILE,
                        message: "请输入手机号",
                    },
                ],
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
        setData(data) {
            //可以和上面一样单个注入，也可以像下面一样直接合并进去
            Object.assign(this.form, data);
        },
    },
};
</script>

<style></style>