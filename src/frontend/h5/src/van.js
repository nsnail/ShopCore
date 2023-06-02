import 'vant/lib/index.css'
import {
    ActionBar,
    ActionBarButton,
    ActionBarIcon,
    Button,
    Cell,
    CellGroup,
    Col,
    ContactCard,
    Field,
    Form,
    Grid,
    GridItem,
    Icon,
    Image,
    Lazyload,
    Notify,
    NumberKeyboard,
    PasswordInput,
    PullRefresh,
    Row,
    Search,
    Step,
    Steps,
    Tab,
    Tabbar,
    TabbarItem,
    Tabs,
    Toast,
    TreeSelect
} from 'vant'

export default {
    install(app) {
        app.use(Button)
        app.use(Form)
        app.use(Field)
        app.use(CellGroup)
        app.use(Cell)
        app.use(Steps)
        app.use(Step)
        app.use(PasswordInput)
        app.use(NumberKeyboard)
        app.use(Notify)
        app.use(Toast)
        app.use(ContactCard)
        app.use(Row)
        app.use(Col)
        app.use(Icon)
        app.use(Tabbar)
        app.use(TabbarItem)
        app.use(Grid)
        app.use(GridItem)
        app.use(Image)
        app.use(Lazyload)
        app.use(PullRefresh)
        app.use(Search)
        app.use(Tabs)
        app.use(Tab)
        app.use(TreeSelect)
        app.use(ActionBar)
        app.use(ActionBarButton)
        app.use(ActionBarIcon)
    }
}