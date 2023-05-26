<template>
    <el-row :gutter="40">
        <el-col v-if="!form.id">
            <el-empty
                :image-size="100"
                description="请选择左侧商品分类后操作"
            ></el-empty>
        </el-col>
        <template v-else>
            <el-col>
                <h2>{{ form.categoryName || "新增商品分类" }}</h2>
                <el-form
                    ref="dialogForm"
                    :model="form"
                    :rules="rules"
                    label-position="left"
                    label-width="100px"
                >
                    <el-form-item label="显示名称" prop="categoryName">
                        <el-input
                            v-model="form.categoryName"
                            clearable
                            placeholder="商品分类显示名字"
                        ></el-input>
                    </el-form-item>
                    <el-form-item label="上级商品分类" prop="parentId">
                        <el-cascader
                            v-model="form.parentId"
                            :options="treeOptions"
                            :props="treeProps"
                            :show-all-levels="false"
                            clearable
                            placeholder="顶级商品分类"
                        ></el-cascader>
                    </el-form-item>
                    <el-form-item label="排序" prop="sort">
                        <el-input-number
                            v-model="form.sort"
                            :min="0"
                            controls-position="right"
                            style="width: 100%"
                        ></el-input-number>
                    </el-form-item>
                    <el-form-item>
                        <el-button
                            :loading="loading"
                            type="primary"
                            @click="save"
                            >保 存
                        </el-button>
                    </el-form-item>
                </el-form>
            </el-col>
        </template>
    </el-row>
</template>

<script>
export default {
    components: {},
    props: {
        tree: {
            type: Object,
            default: () => {},
        },
    },
    data() {
        return {
            form: {
                id: 0,
                parentId: 0,
                categoryName: "",
                sort: 0,
            },
            treeOptions: [],
            treeProps: {
                emitPath: false,
                value: "id",
                label: "categoryName",
                checkStrictly: true,
            },
            rules: {
                categoryName: {
                    required: true,
                    message: "请输入显示名称",
                },
            },
            loading: false,
        };
    },
    watch: {
        tree: {
            handler() {
                this.treeOptions = this.treeToMap(this.tree);
            },
            deep: true,
        },
    },
    mounted() {},
    methods: {
        //简单化商品分类
        treeToMap(tree) {
            const map = [];
            tree.forEach((item) => {
                const obj = {
                    id: item.id,
                    parentId: item.parentId,
                    categoryName: item.categoryName,
                    children:
                        item.children && item.children.length > 0
                            ? this.treeToMap(item.children)
                            : null,
                };
                map.push(obj);
            });
            return map;
        },
        //保存
        async save() {
            await this.$refs.dialogForm.validate(async (valid) => {
                if (valid) {
                    this.loading = true;
                    try {
                        if (!this.form.parentId) this.form.parentId = 0;
                        const res = await this.$API[
                            "biz_productcategory"
                        ].update.post(this.form);
                        this.$message.success("保存成功");
                        this.$emit("success", res.data);
                    } catch {}
                    this.loading = false;
                }
            });
        },
        //表单注入数据
        setData(data, pid) {
            this.form = data;
            this.form.parentId = pid;
        },
    },
};
</script>

<style scoped>
h2 {
    font-size: 17px;
    color: #3c4a54;
    padding: 0 0 30px 0;
}

[data-theme="dark"] h2 {
    color: #fff;
}
</style>