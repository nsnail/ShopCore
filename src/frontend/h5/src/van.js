import 'vant/lib/index.css'
import {
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
    Notify,
    NumberKeyboard,
    PasswordInput,
    Row,
    Step,
    Steps,
    Tabbar,
    TabbarItem,
    Toast
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
    }
}