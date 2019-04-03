using System;
using Nez;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

using Nez.UI;

namespace MapEditor.Desktop
{
    public class MainScene : Scene
    {

        Entity _entity;
        Table _table;
        UICanvas _canvas;

        public MainScene()
        {
            addRenderer(new DefaultRenderer());

            

        }


        public override void initialize()
        {
            base.initialize();

            //_entity
        }

        public override void onStart()
        {
            base.onStart();

            _entity = Core.scene.createEntity("ui root");
            _canvas = new UICanvas();
            _table = new Table();
            _table.setFillParent(true);
            _entity.addComponent(_canvas);
            _canvas.stage.addElement(_table);
            //new TextButton();
            var button = new TextButton("Play Game", TextButtonStyle.create(Color.Black, Color.DarkGray, Color.Green));
            _table.add(button).setMinWidth(100).setMinHeight(30).setPadTop(570).setPadLeft(0);
            button.onClicked += PlayGame;
            //_table.getCell(button).setPadTop(0);

                      

        }

        private void PlayGame(Button obj)
        {
            Debug.log("play game");
        }

        private List<Vector2> maps = new List<Vector2>();

        public override void update()
        {
            base.update();

            return;
            if (Input.leftMouseButtonPressed) 
            {
                maps.Add(GetMapTilePositionWithInputMousePosition(Input.mousePosition));
            }

            if(Input.rightMouseButtonDown)
            { 
                if(!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();
                }

                using (var sw = new StreamWriter(new FileStream(fileName, FileMode.Truncate)))   
                {
                    var ser = new XmlSerializer(typeof(List<Vector2>));
                    ser.Serialize(sw, maps);

                }

                //var settting = new XmlWriterSettings();
                //settting.Indent = true;
                //using (var sw = XmlWriter.Create(fileName, settting))
                //{
                //    IntermediateSerializer.Serialize(sw, maps, null);
                //}
            }

            if(Input.isKeyDown(Keys.P))
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();
                }

                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
                {
                    var ser = new XmlSerializer(typeof(List<Vector2>));
                    maps = (List<Vector2>)ser.Deserialize(sr);

                }

                //var settting = new XmlReaderSettings();
                //settting.CheckCharacters = true;
                //using (var sr = XmlReader.Create(fileName, settting))
                //{
                //    maps = (List<Vector2>)IntermediateSerializer.Deserialize<List<Vector2>>(sr, null);
                //}

                foreach (var map in maps)
                {
                    GetMapTilePositionWithInputMousePosition(map);
                }
            }
        }

        private string fileName = "map.xml";

        private Vector2 GetMapTilePositionWithInputMousePosition(Vector2 mousePosition)
        {
            Texture2D texture = new Texture2D(Core.graphicsDevice, 20, 20);

            float[] data = new float[1600];
            texture.GetData<float>(data, 0, 400);
            Debug.log(data[20]);
            for(int index = 0, size = data.Length; index < size; index++)
            {
                data[index] = 20;
            }
            texture.SetData<float>(data, 0, 400);
            Debug.log(data[20]);

            var entity = Core.scene.createEntity("");
            entity.addComponent(new Sprite(texture));
            entity.transform.position = new Vector2(((int)mousePosition.X / 20) * 20 + 10, ((int)mousePosition.Y / 20) * 20 + 10);

            return entity.transform.position;
        }
    }
}
