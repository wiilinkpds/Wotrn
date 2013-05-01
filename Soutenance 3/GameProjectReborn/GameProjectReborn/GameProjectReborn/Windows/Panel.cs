using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows.SubWindows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Windows
{
    class Panel : Window
    {
        private InfoPlayer infoPlayerWindow;
        private SpellList spellListWindow;

        private Button infoPlayerButton;
        private Button spellListButton;

        public Panel(Screen parent, Vector2 position, Texture2D texture,Player player) : base(parent, position, texture)
        {
            infoPlayerWindow = new InfoPlayer(parent, new Vector2(MainGame.ScreenX - 200, 5), TexturesManager.Window ,player);
            spellListWindow = new SpellList(parent, new Vector2(MainGame.ScreenX - 500, 5), TexturesManager.Window, player);

            infoPlayerButton = new Button(position, TexturesManager.InfoButton);
            spellListButton = new Button(position + new Vector2(0, TexturesManager.SpellButton.Height), TexturesManager.SpellButton);

            infoPlayerButton.MouseClick += OnInfoPlayerMouseClick;
            spellListButton.MouseClick += OnSpellListMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            infoPlayerButton.Update(gameTime);
            spellListButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            infoPlayerButton.Draw(gameTime, spriteBatch);
            spellListButton.Draw(gameTime, spriteBatch);
        }

        public void OnInfoPlayerMouseClick(object sender, MouseClickEventArgs e)
        {
            infoPlayerWindow.IsOpened = !infoPlayerWindow.IsOpened;

            if (infoPlayerWindow.IsOpened)
                Parent.Windows.Add(infoPlayerWindow);
            else
                Parent.Windows.Remove(infoPlayerWindow);
        }

        public void OnSpellListMouseClick(object sender, MouseClickEventArgs e)
        {
            spellListWindow.IsOpened = !spellListWindow.IsOpened;

            if (spellListWindow.IsOpened)
                Parent.Windows.Add(spellListWindow);
            else
                Parent.Windows.Remove(spellListWindow);
        }
    }
}
