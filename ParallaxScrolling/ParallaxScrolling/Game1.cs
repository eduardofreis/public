using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//using Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework.Storage;

namespace ParallaxScrolling
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		//lista de camadas
		List<ParallaxLayer> layers;

		//velocidade de movimentação da camada principal
		float velocidadePrincipal = 100f;
		//velocidade da camada de montanhas
		float velocidadeMontanhas = 0.3f;
		//velocidade da camada de grama
		float velocidadeGrama = 0.85f;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			//define a largura da tela
			graphics.PreferredBackBufferWidth = 640;
			//define a altura da tela
			graphics.PreferredBackBufferHeight = 400;

			Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;	
		}

		/// <summary>
		/// Inicializa os componentes do jogo
		/// </summary>
		protected override void Initialize()
		{
			this.layers = new List<ParallaxLayer>();

			ParallaxLayer background = new ParallaxLayer(0, 0);
			//cria a camada de montanhas
			ParallaxLayer montanhas = new ParallaxLayer(velocidadePrincipal * velocidadeMontanhas, 0);
			//cria a camda de grama
			ParallaxLayer grama = new ParallaxLayer(velocidadePrincipal * velocidadeGrama, 0);
			//cria a camada principal (árvores)
			ParallaxLayer basica = new ParallaxLayer(velocidadePrincipal, 0);

			//adiciona as camadas
			this.layers.Add(background);
			this.layers.Add(montanhas);
			this.layers.Add(grama);
			this.layers.Add(basica);

			base.Initialize();
		}

		/// <summary>
		/// Carrega os componentes gráficos
		/// </summary>
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			//carrega as imagens das camadas
			this.layers[0].LoadContent(Content, @"images/ceu");
			this.layers[1].LoadContent(Content, @"images/montanhas");
			this.layers[2].LoadContent(Content, @"images/grama");
			this.layers[3].LoadContent(Content, @"images/principal");
		}

		/// <summary>
		/// Descarrega os componentes gráficos
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Atualiza os componentes</summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			foreach (ParallaxLayer layer in this.layers)
			{
				layer.Update(gameTime);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// Desenha os componentes na tela
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			//desenha as camadas na tela
			foreach (ParallaxLayer layer in this.layers)
			{
				layer.Draw(spriteBatch);
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
