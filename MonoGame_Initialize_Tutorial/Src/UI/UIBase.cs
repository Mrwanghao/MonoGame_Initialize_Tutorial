using Nez;
using Nez.UI;




namespace UI
{
    public abstract class UIBase
    {

        public UIBase()
        {
            BeforeCreate();

            _entity = CreateEntity();
            _canvas = CreateUICanvas();
            _table = CreateTable();

            _entity.addComponent(_canvas);
            _canvas.stage.addElement(_table);

            AfterCreate();
        }

        public virtual void BeforeCreate() { }
        public virtual void AfterCreate() { }

        public void Show() { _entity.enabled = true; }
        public void Hide() { _entity.enabled = false; }
        public void Toggle() { _entity.setEnabled(!_entity.enabled); }

        public void Destroy() 
        {
            OnDestroy();

            _entity = null;
            _canvas = null;
            _table = null;
        }

        protected virtual void Update() { }
        protected virtual void OnDestroy() { }

        protected Entity _entity;
        protected UICanvas _canvas;
        protected Table _table;

        protected abstract Entity CreateEntity();
        protected abstract UICanvas CreateUICanvas();
        protected abstract Table CreateTable();
    }
}
