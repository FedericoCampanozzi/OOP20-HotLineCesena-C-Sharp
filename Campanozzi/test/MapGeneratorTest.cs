using System;
using System.Collections.Generic;
using NUnit.Framework;
using Campanozzi.Controller.Generator;
using Campanozzi.Model.DataAccessLayer;

namespace CampanozziTest
{
	public class MapGeneratorTest
	{
		[Test]
		public void VisualTest()
		{
			try
			{
				IWorldGeneratorBuilder<RectangularRoom> sgwb = new RectangularWorldGeneratorBuilder()
					.AddSomeBaseRoom(new BaseRoomsGeneratorFactory().GenerateRectungolarRoomList(5, 13, 5, 13, 1, 4,15, 25))
					.GenerateRooms(1, 2)
					.GeneratePlayer()
					.GenerateKeyObject()
					.GenerateEnemy(1, 3)
					.GenerateItem(1, 3)
					.GenerateWeapons(1, 3)
					.GenerateObstacoles(1, 3)
					.Finishes()
					.Build();
				
				for(int i = sgwb.MinX; i < sgwb.MaxX; i++)
                {
					for (int j = sgwb.MinY; j < sgwb.MaxY; j++)
					{
						Console.Write((char)sgwb.Map[new KeyValuePair<int, int>(i, j)]);
					}
					Console.WriteLine();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("FAIL TO GENERATE :\n" + e.Message);
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