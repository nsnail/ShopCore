<template>
    <el-container>
        <el-aside
            v-loading="showTreeLoading"
            class="el-aside-filter"
            width="200px"
        >
            <el-collapse v-model="activeNames">
                <el-collapse-item name="1" title="分类筛选">
                    <el-container>
                        <el-header>
                            <el-input
                                v-model="cateFilterText"
                                clearable
                                placeholder="输入关键字进行过滤"
                            ></el-input>
                        </el-header>
                        <el-main class="nopadding">
                            <el-tree
                                ref="cate"
                                :current-node-key="''"
                                :data="cate"
                                :expand-on-click-node="true"
                                :filter-node-method="cateFilterNode"
                                :highlight-current="true"
                                :props="cateProps"
                                class="menu"
                                default-expand-all
                                node-key="id"
                                @node-click="cateClick"
                            ></el-tree>
                        </el-main>
                    </el-container>
                </el-collapse-item>
            </el-collapse>
        </el-aside>
        <el-container>
            <el-header>
                <div class="left-panel">
                    <el-button
                        icon="el-icon-plus"
                        type="primary"
                        @click="add"
                    ></el-button>
                    <el-button
                        :disabled="selection.length === 0"
                        icon="el-icon-delete"
                        plain
                        type="danger"
                        @click="batch_del"
                    ></el-button>
                </div>
                <div class="right-panel">
                    <form class="right-panel-search" @submit.prevent="upSearch">
                        <el-input
                            v-model="queryParams.keywords"
                            clearable
                            placeholder="商品编号 / 名称 / 描述"
                            style="width: 200px"
                        ></el-input>
                        <el-button
                            icon="el-icon-search"
                            type="primary"
                            @click="upSearch"
                        ></el-button>
                    </form>
                </div>
            </el-header>
            <el-main class="nopadding">
                <scTable
                    ref="table"
                    v-loading="loading"
                    :apiObj="apiObj"
                    :default-sort="{ prop: 'createdTime', order: 'descending' }"
                    :filter-method="filterMethod"
                    :params="queryParams"
                    remote-filter
                    remote-sort
                    stripe
                    @selection-change="selectionChange"
                >
                    <el-table-column type="selection"></el-table-column>
                    <el-table-column
                        label="商品编号"
                        prop="id"
                        sortable="custom"
                        width="150"
                    ></el-table-column>
                    <el-table-column
                        label="商品名称"
                        prop="name"
                        sortable="custom"
                    >
                        <template #default="scope">
                            <div style="display: flex; flex-direction: row">
                                <div style="margin-right: 10px">
                                    <el-avatar
                                        :src="getImageUrl(scope)"
                                        size="small"
                                    ></el-avatar>
                                </div>
                                <div style="flex-grow: 1">
                                    {{ scope.row.name }}
                                </div>
                            </div>
                        </template>
                    </el-table-column>
                    <el-table-column
                        align="center"
                        label="所属分类"
                        prop="category.categoryName"
                        sortable="custom"
                    ></el-table-column>
                    <el-table-column
                        align="right"
                        label="单价"
                        prop="price"
                        sortable="custom"
                        width="120"
                    ></el-table-column>
                    <el-table-column
                        align="right"
                        label="库存"
                        prop="stock"
                        sortable="custom"
                        width="120"
                    ></el-table-column>
                    <el-table-column
                        label="创建时间"
                        prop="createdTime"
                        sortable="custom"
                    ></el-table-column>
                    <el-table-column align="right" fixed="right" label="操作">
                        <template #default="scope">
                            <el-button-group>
                                <el-button
                                    icon="el-icon-view"
                                    size="small"
                                    @click="table_view(scope.row)"
                                ></el-button>
                                <el-button
                                    icon="el-icon-edit"
                                    size="small"
                                    type="primary"
                                    @click="table_edit(scope.row)"
                                ></el-button>
                                <el-popconfirm
                                    title="确定删除吗？"
                                    @confirm="
                                        table_del(scope.row, scope.$index)
                                    "
                                >
                                    <template #reference>
                                        <el-button
                                            icon="el-icon-delete"
                                            size="small"
                                            type="danger"
                                        ></el-button>
                                    </template>
                                </el-popconfirm>
                            </el-button-group>
                        </template>
                    </el-table-column>
                </scTable>
            </el-main>
        </el-container>
    </el-container>

    <save-dialog
        v-if="dialog.save"
        ref="saveDialog"
        @closed="dialog.save = false"
        @success="handleSuccess"
    ></save-dialog>
    <cate-save-dialog
        v-if="dialog.cateSave"
        ref="cateSaveDialog"
        @closed="dialog.cateSave = false"
    >
    </cate-save-dialog>
</template>

<script>
import saveDialog from "./save";
import cateSaveDialog from "@/views/biz/product-category/save.vue";

export default {
    components: {
        saveDialog,
        cateSaveDialog,
    },
    data() {
        return {
            loading: false,
            queryParams: {
                filter: { categoryId: 0 },
                dynamicFilter: {
                    logic: "and",
                    filters: [
                        {
                            logic: "or",
                            filters: [],
                        },
                    ],
                },
            },
            activeNames: ["1", "2", "3"],
            dialog: {
                cateSave: false,
                save: false,
                info: false,
            },
            showTreeLoading: false,
            cateFilterText: "",
            cate: [],
            cateProps: {
                label: (data) => data.categoryName,
            },
            apiObj: this.$API["biz_product"].pagedQuery,
            selection: [],
        };
    },
    watch: {
        cateFilterText(val) {
            this.$refs.cate.filter(val);
        },
    },
    computed: {},
    mounted() {
        this.getTree();
    },
    methods: {
        async userCateClick(item) {
            this.loading = true;
            const cate = await this.$API["biz_productcategory"].query.post({
                filter: { id: item.id },
            });
            this.loading = false;
            this.dialog.cateSave = true;
            this.$nextTick().then(() => {
                this.$refs.cateSaveDialog.open("view").setData(cate.data[0]);
            });
        },
        filterMethod(filters) {
            if (filters.enabled) {
                this.queryParams.dynamicFilter.filters =
                    this.queryParams.dynamicFilter.filters.filter(
                        (x) => x.field !== "enabled"
                    );
                if (filters.enabled.length > 0) {
                    this.queryParams.dynamicFilter.filters.push({
                        field: "enabled",
                        operator: "Any",
                        value: filters.enabled,
                    });
                }
            }
            this.$refs.table.upData();
        },
        //添加
        add() {
            this.dialog.save = true;
            this.$nextTick(() => {
                this.$refs.saveDialog.open();
            });
        },
        //编辑
        table_edit(row) {
            this.dialog.save = true;
            this.$nextTick(() => {
                this.$refs.saveDialog.open("edit").setData(row);
            });
        },
        //查看
        table_view(row) {
            this.dialog.save = true;
            this.$nextTick(() => {
                this.$refs.saveDialog.open("view").setData(row);
            });
        },
        //删除
        async table_del(row, index) {
            const reqData = { id: row.id };
            const res = await this.$API["biz_product"].delete.post(reqData);
            if (res.code === "succeed") {
                //这里选择刷新整个表格 OR 插入/编辑现有表格数据
                this.$refs.table.tableData.splice(index, 1);
                this.$message.success("删除成功");
            } else {
                await this.$alert(res.message, "提示", { type: "error" });
            }
        },
        //批量删除
        async batch_del() {
            try {
                await this.$confirm(
                    `确定删除选中的 ${this.selection.length} 项吗？`,
                    "提示",
                    {
                        type: "warning",
                    }
                );
                const loading = this.$loading();
                await this.$API["biz_product"].bulkDelete.post({
                    items: this.selection,
                });
                this.selection.forEach((item) => {
                    this.$refs.table.tableData.forEach((itemI, indexI) => {
                        if (item.id === itemI.id) {
                            this.$refs.table.tableData.splice(indexI, 1);
                        }
                    });
                });
                loading.close();
                this.$message.success("操作成功");
            } catch {}
        },
        //表格选择后回调事件
        selectionChange(selection) {
            this.selection = selection;
        },
        //加载树数据
        async getTree() {
            this.showTreeLoading = true;

            //加载分类数据
            let res = await this.$API["biz_productcategory"].query.post();
            let allNode = { id: "", categoryName: "所有分类" };
            res.data.unshift(allNode);
            this.cate = res.data;

            this.showTreeLoading = false;
        },
        //分类树过滤
        cateFilterNode(value, data) {
            if (!value) return true;
            return data.categoryName.indexOf(value) !== -1;
        },
        //分类树点击事件
        cateClick(data, node) {
            if (!node.isLeaf) return;
            this.queryParams.filter.categoryId = data.id ? data.id : 0;
            this.$refs.table.upData();
        },
        //搜索
        upSearch() {
            this.queryParams.dynamicFilter.filters[0].filters = [
                {
                    field: "name",
                    operator: "contains",
                    value: this.queryParams.keywords,
                },
                {
                    field: "description",
                    operator: "contains",
                    value: this.queryParams.keywords,
                },
                {
                    field: "id",
                    operator: "contains",
                    value: this.queryParams.keywords,
                },
            ];
            this.$refs.table.upData();
        },
        //本地更新数据
        handleSuccess(data, mode) {
            if (mode === "add") {
                this.$refs.table.tableData.unshift(data);
            } else if (mode === "edit") {
                this.$refs.table.tableData
                    .filter((item) => item.id === data.id)
                    .forEach((item) => {
                        Object.keys(item).forEach((x) => delete item[x]);
                        Object.assign(item, data);
                    });
            }
        },
        //获取头像
        getImageUrl(scope) {
            return scope.row.imageUrl
                ? scope.row.imageUrl
                : this.$CONFIG.DEF_AVATAR;
        },
    },
};
</script>

<style scoped>
.el-aside-filter {
    background: var(--el-bg-color);
    padding: 10px;
}
</style>