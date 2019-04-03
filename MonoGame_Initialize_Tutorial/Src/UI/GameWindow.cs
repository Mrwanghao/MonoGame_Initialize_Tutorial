using Nez;
using Nez.UI;
using Microsoft.Xna.Framework;

namespace UI
{
    public class GameWindow : UIBase
    {
        protected override Entity CreateEntity()
        {
            return Core.scene.createEntity("GameWindow");
        }

        protected override Table CreateTable()
        {
            Table table = new Table();
            //table.setFillParent(true);
            return table;
        }

        protected override UICanvas CreateUICanvas()
        {
            UICanvas canvas = new UICanvas();
            return canvas;
        }

        public override void AfterCreate()
        {
            base.AfterCreate();

            text_button = AddButton("Save Map Button", 100, 200);
            text_button.onClicked += Text_Button_OnClicked;
        }

        private TextButton text_button;

        void Text_Button_OnClicked(Button obj)
        {
            Debug.log(obj);
        }


        public override void Update()
        {
            base.Update();

        }

        private TextButton AddButton(string text, float left, float top)
        {
            TextButton text_button = new TextButton(text, TextButtonStyle.create(Color.Blue, Color.Black, Color.Red));
            Cell cell = _table.add(text_button);
            cell.setMinWidth(100).setMinHeight(30);
            cell.setPadLeft(100).setPadTop(30);
            return text_button;
        }
    }
}
