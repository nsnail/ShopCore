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
                    <el-form-item label="商品图片" prop="imageUrl">
                        <sc-upload
                            v-model="form.imageUrl"
                            title="上传商品图片"
                        ></sc-upload>
                    </el-form-item>
                    <el-form-item label="所属分类" prop="categoryId">
                        <el-cascader
                            v-model="form.categoryId"
                            :options="cates"
                            :props="catesProps"
                            clearable
                            style="width: 100%"
                        ></el-cascader>
                    </el-form-item>
                    <el-form-item label="商品名称" prop="name">
                        <el-input
                            v-model="form.name"
                            clearable
                            placeholder="商品标题信息"
                        ></el-input>
                    </el-form-item>
                    <el-form-item label="商品单价" prop="price">
                        <el-input-number
                            v-model="form.price"
                            :min="0"
                            controls-position="right"
                            style="width: 100%"
                        ></el-input-number>
                    </el-form-item>
                    <el-form-item label="商品库存" prop="stock">
                        <el-input-number
                            v-model="form.stock"
                            :min="0"
                            controls-position="right"
                            style="width: 100%"
                        ></el-input-number>
                    </el-form-item>
                    <el-form-item label="商品描述" prop="description">
                        <el-input
                            v-model="form.description"
                            :autosize="{ minRows: 5, maxRows: 10 }"
                            clearable
                            placeholder="商品详细描述"
                            type="textarea"
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
                view: "查看商品",
                add: "新增商品",
                edit: "编辑商品",
            },
            visible: false,
            isSaving: false,
            //表单数据
            form: {
                imageUrl: "",
                name: "",
                description: "",
                price: 0,
                stock: 100,
            },
            //验证规则
            rules: {
                name: [
                    {
                        required: true,
                        message: "请输入商品名称",
                    },
                ],
                imageUrl: [
                    {
                        required: true,
                        message: "请上传商品图片",
                    },
                ],
                description: [
                    {
                        required: true,
                        message: "请输入商品描述",
                    },
                ],
                categoryId: [
                    {
                        required: true,
                        message: "请选择商品分类",
                    },
                ],
            },
            //所需数据选项
            cates: [],
            catesProps: {
                label: "categoryName",
                emitPath: false,
                value: "id",
                checkStrictly: false,
            },
        };
    },
    mounted() {
        this.getCates();
    },
    methods: {
        //显示
        open(mode = "add") {
            this.mode = mode;
            this.visible = true;
            return this;
        },
        async getCates() {
            const res = await this.$API["biz_productcategory"].query.post();
            this.cates = res.data;
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
                                ? this.$API["biz_product"].create
                                : this.$API["biz_product"].update;
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