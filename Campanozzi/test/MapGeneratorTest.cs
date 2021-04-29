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
		private const int N_IMAGE = 5;
		private const int PIXEL_SIZE = 15;
		private const string PROJECT_NAME = "Campanozzi";
		private string _projectPath = "";
		private bool _setup = false;

		private void SetUp()
        {
            if (_setup)
            {
				return;
            }

			_setup = true;

			string[] pathPart = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
			for (int i = 0; i < pathPart.Length && pathPart[i] == PROJECT_NAME; i++)
			{
				_projectPath += pathPart[i] + Path.DirectorySeparatorChar;
			}

			DirectoryInfo dir = new DirectoryInfo(_projectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "GeneraterMap");

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
		}

		private void SaveMapToBitmap(IDictionary<KeyValuePair<int,int>, SymbolsType> map, int xMin, int xMax, int yMin, int yMax, string path)
        {
			int width = PIXEL_SIZE * (xMax - xMin + 1);
			int height = PIXEL_SIZE * (yMax - yMin + 1);

			Bitmap bmp = new Bitmap(width, height);

			foreach(KeyValuePair<KeyValuePair<int,int>,SymbolsType> v in map)
            {
				int x = v.Key.Key - xMin;
				int y = v.Key.Value - yMin;

				for (int i=0;i< PIXEL_SIZE; i++)
                {
					for(int j = 0; j < PIXEL_SIZE; j++)
                    {
						bmp.SetPixel(PIXEL_SIZE * x + i, PIXEL_SIZE * y + j, v.Value.TestColor);
                    }
                }
            }

			bmp.Save(File.OpenWrite(path), System.Drawing.Imaging.ImageFormat.Bmp);
		}

		[Test]
		public void VisualTestOctagonalWorldGeneratorBuilder()
		{
			try
			{
				SetUp();
				for (int n = 0; n < N_IMAGE; n++)
				{
					JSONDataAccessLayer.generateNewSeed();

					IWorldGeneratorBuilder<OctagonalRoom> gen = new OctagonalWorldGeneratorBuilder()
						.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateOctagonalRoomList(3, 5, 1, 4, 15, 25))
						.GenerateRooms(1, 2)
						.GeneratePlayer()
						.GenerateKeyObject()
						.GenerateEnemy(1, 3)
						.GenerateItem(1, 3)
						.GenerateWeapons(1, 3)
						.GenerateObstacoles(1, 3)
						.Finishes()
						.Build();

					SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
						_projectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "GeneraterMap" + Path.DirectorySeparatorChar + "TestE[" + JSONDataAccessLayer._seed + "].bmp");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("FAIL TO GENERATE :\n" + e.Message + "\n" + e.StackTrace);
			}
		}

		[Test]
		public void VisualTestQuadraticWorldGeneratorBuilder()
		{
			try
			{
				SetUp();
				for (int n = 0; n < N_IMAGE; n++)
				{
					JSONDataAccessLayer.generateNewSeed();

					IWorldGeneratorBuilder<QuadraticRoom> gen = new QuadraticWorldGeneratorBuilder()
						.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(5, 13, 1, 4, 15, 25))
						.GenerateRooms(1, 2)
						.GeneratePlayer()
						.GenerateKeyObject()
						.GenerateEnemy(1, 3)
						.GenerateItem(1, 3)
						.GenerateWeapons(1, 3)
						.GenerateObstacoles(1, 3)
						.Finishes()
						.Build();

					SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
						_projectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "GeneraterMap" + Path.DirectorySeparatorChar + "TestQ[" + JSONDataAccessLayer._seed + "].bmp");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("FAIL TO GENERATE :\n" + e.Message + "\n" + e.StackTrace);
			}
		}

		[Test]
		public void VisualTestRectangularWorldGeneratorBuilder()
		{
			try
			{
				SetUp();
				for (int n = 0; n < N_IMAGE; n++)
				{
					JSONDataAccessLayer.generateNewSeed();

					IWorldGeneratorBuilder<RectangularRoom> gen = new RectangularWorldGeneratorBuilder()
						.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateRectungolarRoomList(5, 13, 5, 13, 1, 4, 15, 25))
						.GenerateRooms(1, 2)
						.GeneratePlayer()
						.GenerateKeyObject()
						.GenerateEnemy(1, 3)
						.GenerateItem(1, 3)
						.GenerateWeapons(1, 3)
						.GenerateObstacoles(1, 3)
						.Finishes()
						.Build();

					SaveMapToBitmap(gen.Map, gen.MinX, gen.MaxX, gen.MinY, gen.MaxY,
						_projectPath + Path.DirectorySeparatorChar + "test" + Path.DirectorySeparatorChar + "GeneraterMap" + Path.DirectorySeparatorChar + "TestR[" + JSONDataAccessLayer._seed + "].bmp");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("FAIL TO GENERATE :\n" + e.Message + "\n" + e.StackTrace);
			}
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
					.GenerateRooms(1, 2)
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
					.GenerateRooms(1, 2)
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
				.GenerateRooms(1, 2)
				.GeneratePlayer()
				.GenerateEnemy(1, 2)
				.GenerateItem(1, 2)
				.GenerateWeapons(1, 2)
				.GenerateObstacoles(1, 2)
				.Finishes()
				.Build();

			new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
				.GenerateRooms(1, 2)
				.GeneratePlayer()
				.GenerateWeapons(1, 2)
				.GenerateItem(1, 2)
				.GenerateEnemy(1, 2)
				.GenerateObstacoles(1, 2)
				.Finishes()
				.Build();


			new QuadraticWorldGeneratorBuilder()
				.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateQuadraticRoomList(8, 10, 1, 2, 3, 4))
				.GenerateRooms(1, 2)
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