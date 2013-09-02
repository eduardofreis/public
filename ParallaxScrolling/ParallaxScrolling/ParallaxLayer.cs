using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ParallaxScrolling
{
	public class ParallaxLayer
	{
		private Texture2D imagem;
		private Vector2 posicao;
		private Vector2 velocidade;

		public Vector2 Posicao
		{
			get { return this.posicao; }
			set { this.posicao = value; }
		}

		public ParallaxLayer(float velX, float velY)
		{
			this.posicao = new Vector2(0, 0);
			this.velocidade = new Vector2(velX, velY);
		}

		public void LoadContent(ContentManager content, string filename)
		{
			this.imagem = content.Load<Texture2D>(filename);
		}

		public void Update(GameTime gameTime)
		{
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			this.posicao.X -= this.velocidade.X * deltaTime;
			this.posicao.X = this.posicao.X % this.imagem.Width;

			/*
            if (this.posicao.X < -this.imagem.Width)
                this.posicao.X = 0;
             */
		}

		public void Draw(SpriteBatch batch)
		{
			batch.Draw(this.imagem, this.posicao, Color.White);
			batch.Draw(this.imagem, new Vector2(this.posicao.X + this.imagem.Width, 0), Color.White);
		}
	}
}
