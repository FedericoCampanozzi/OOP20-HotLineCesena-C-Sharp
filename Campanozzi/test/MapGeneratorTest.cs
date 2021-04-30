using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Drawing;
using System.IO;
using Campanozzi.Controller.Generator;
using Campanozzi.Model.DataAccessLayer;

namespace CampanozziTest
{
	/// <summary>
	/// Test Generator Namespace
	/// </summary>
	public class MapGeneratorTest
	{
		private const int N_IMAGE = 10;
		private const int PIXEL_SIZE = 10;

		[Test]
		public void VisualTestGenerator()
		{
			DirectoryInfo dir = new DirectoryInfo(JSONDataAccessLayer.GetInstance().ProjectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "generatermap");
			if (!dir.Exists)
			{
				dir.Create();
			}
			else
			{
				foreach (FileInfo f in dir.GetFiles())
				{
					File.Delete(f.FullName);
				}
			}

			for (int i = 0; i < N_IMAGE; i++)
			{
				JSONDataAccessLayer.GenerateNewSeed();
				GenerateQuadratic();
				GenerateRectangular();
				GenerateEsagonal();
			}

			Console.WriteLine("Finish");
		}

		private void GenerateEsagonal()
		{
			try
			{
				IWorldGeneratorBuilder<OctagonalRoom> gen = new OctagonalWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateOctagonalRoomList(3, 5, 1, 4, 15, 25))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateKeyObject()
				.GenerateEnemy(1, 3)
				.GenerateItem(1, 3)
				.GenerateWeapons(1, 3)
				.GenerateObstacoles(1, 3)
				.Finishes()
				.Build();

				SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
					JSONDataAccessLayer.GetInstance().ProjectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "generatermap" + Path.DirectorySeparatorChar + "TestE[" + JSONDataAccessLayer._seed + "].bmp");
			}
			catch (Exception)
			{
				Console.WriteLine("FAIL TO GENERATE QUADRATIC");
			}
		}

		private void GenerateQuadratic()
		{
			try
			{
				IWorldGeneratorBuilder<QuadraticRoom> gen = new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(5, 13, 1, 4, 15, 25))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateKeyObject()
				.GenerateEnemy(1, 3)
				.GenerateItem(1, 3)
				.GenerateWeapons(1, 3)
				.GenerateObstacoles(1, 3)
				.Finishes()
				.Build();

				SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
					JSONDataAccessLayer.GetInstance().ProjectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "generatermap" + Path.DirectorySeparatorChar + "TestQ[" + JSONDataAccessLayer._seed + "].bmp");

			}
			catch (Exception)
			{
				Console.WriteLine("FAIL TO GENERATE QUADRATIC");
			}
		}

		private void GenerateRectangular()
		{
			try
			{
				IWorldGeneratorBuilder<RectangularRoom> gen = new RectangularWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateRectungolarRoomList(5, 13, 5, 13, 1, 4, 15, 25))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateKeyObject()
				.GenerateEnemy(1, 3)
				.GenerateItem(1, 3)
				.GenerateWeapons(1, 3)
				.GenerateObstacoles(1, 3)
				.Finishes()
				.Build();

				SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
					JSONDataAccessLayer.GetInstance().ProjectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "generatermap" + Path.DirectorySeparatorChar + "TestR[" + JSONDataAccessLayer._seed + "].bmp");

			}
			catch (Exception)
			{
				Console.WriteLine("FAIL TO GENERATE QUADRATIC");
			}
		}

		private void SaveMapToBitmap(IDictionary<KeyValuePair<int, int>, SymbolsType> map, int xMin, int xMax, int yMin, int yMax, string path)
		{
			int width = PIXEL_SIZE * (xMax - xMin + 1);
			int height = PIXEL_SIZE * (yMax - yMin + 1);

			Bitmap bmp = new Bitmap(width, height);

			foreach (KeyValuePair<KeyValuePair<int, int>, SymbolsType> v in map)
			{
				int x = v.Key.Key - xMin;
				int y = v.Key.Value - yMin;

				for (int i = 0; i < PIXEL_SIZE; i++)
				{
					for (int j = 0; j < PIXEL_SIZE; j++)
					{
						Color c = Color.FromArgb(255, 0, 0, 0);
                        switch (v.Value)
                        {
							case (SymbolsType.WALKABLE):
								c = Color.White;
								break;
							case (SymbolsType.WALL):
								c = Color.SaddleBrown;
								break;
							case (SymbolsType.DOOR):
								c = Color.Yellow;
								break;
							case (SymbolsType.VOID):
								c = Color.Green;
								break;
							case (SymbolsType.WEAPONS):
								c = Color.Blue;
								break;
							case (SymbolsType.PLAYER):
								c = Color.MediumPurple;
								break;
							case (SymbolsType.OBSTACOLES):
								c = Color.Brown;
								break;
							case (SymbolsType.ENEMY):
								c = Color.Red;
								break;
							case (SymbolsType.KEY_ITEM):
								c = Color.Orange;
								break;
							case (SymbolsType.ITEM):
								c = Color.BlueViolet;
								break;
						}

						bmp.SetPixel(PIXEL_SIZE * x + i, PIXEL_SIZE * y + j, c);
					}
				}
			}

			bmp.Save(File.OpenWrite(path), System.Drawing.Imaging.ImageFormat.Bmp);
		}

		[Test]
		/**
		 * I have to call first addSomeBaseRoom or addSingleRoom
		 * Than generateRooms and than others method
		 */
		public void WrongBuilderFlow()
		{
			try
			{
				new QuadraticWorldGeneratorBuilder()
					.GeneratePlayer()
					.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
					.GenerateRooms(10, 20)
					.GenerateEnemy(1, 2)
					.GenerateItem(1, 2)
					.GenerateWeapons(1, 2)
					.GenerateObstacoles(1, 2)
					.Finishes()
					.Build();
			}
			catch (ArgumentException)
			{

			}
			catch (Exception)
			{
				Assert.IsFalse(true, "Wrong exception thrown, call first addSomeBaseRoom or addSingleRoom");
			}

			try
			{
				new QuadraticWorldGeneratorBuilder()
					.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
					.GeneratePlayer()
					.GenerateRooms(10, 20)
					.GenerateEnemy(1, 2)
					.GenerateItem(1, 2)
					.GenerateWeapons(1, 2)
					.GenerateObstacoles(1, 2)
					.Finishes()
					.Build();
			}
			catch (ArgumentException)
			{

			}
			catch (Exception)
			{
				Assert.IsFalse(true, "Wrong exception thrown, after call addSomeBaseRoom or addSingleRoom call generateRooms");
			}
		}

		[Test]
		/**
		* I can create builder like i want :
		* for example i can call first generateWeapons than generateEnemy or the other way around
		*/
		public void CorrectBuilderFlow()
		{
			new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateEnemy(1, 2)
				.GenerateItem(1, 2)
				.GenerateWeapons(1, 2)
				.GenerateObstacoles(1, 2)
				.Finishes()
				.Build();

			new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateWeapons(1, 2)
				.GenerateItem(1, 2)
				.GenerateEnemy(1, 2)
				.GenerateObstacoles(1, 2)
				.Finishes()
				.Build();


			new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
				.GenerateRooms(10, 20)
				.GeneratePlayer()
				.GenerateObstacoles(1, 2)
				.GenerateEnemy(1, 2)
				.GenerateWeapons(1, 2)
				.Finishes()
				.GenerateItem(1, 2)
				.Build();
		}
	}
}