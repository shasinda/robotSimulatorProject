using System;
using NUnit.Framework;
using RobotSimulationProject;

namespace RobotSimulationProject.Tests
{
	[TestFixture ()]
	public class RobotTest
	{


		[Test ()]
		public void shouldRaiseAnErrorIfRobotNotProperlyPlacedWhenMoving ()
		{
			var robot = new	Robot ();
			var result = robot.Move ();
			Assert.IsFalse (result);
			Assert.AreEqual ("Robot cannot move until it has been properly placed", robot.error);
		}

		[Test ()]
		public void shouldRaiseAnErrorIfRobotNotProperlyPlacedWhenTurning ()
		{
			var robot = new	Robot ();
			var result = robot.TurnRight ();
			Assert.IsFalse (result);
			Assert.AreEqual ("Robot cannot turn until it has been properly placed", robot.error);
		}

		[Test ()]
		public void shouldRaiseAnErrorIfRobotNotProperlyPlacedWhenTryingToGetThePosition ()
		{
			var robot = new	Robot ();
			var result = robot.GetRobotPosition ();
			Assert.AreEqual ("", result);
			Assert.AreEqual ("Robot cannot Get Robot Position until it has been properly placed", robot.error);
		}

		[Test ()]
		public void shouldRaiseAnErrorWhenRobotIsPlacedOutsideTheGrid ()
		{
			var robot = new Robot ();
			var result = robot.PlaceRobot (-2, 0, DirectionFacing.North);
			Assert.IsFalse (result);
			Assert.AreEqual ("Invalid placement, robot cannot place there", robot.error);

			result = robot.PlaceRobot (6, 0, DirectionFacing.South); 
			Assert.IsFalse (result);
			Assert.AreEqual ("Invalid placement, robot cannot place there", robot.error);
		}

		[Test ()]
		public void shouldRaiseAnErrorWhenTryToMoveRobotOutOfTheGrid()
		{

			var robot = new Robot ();
			robot.PlaceRobot (5, 5, DirectionFacing.North);
			var result = robot.Move ();
			Assert.IsFalse (result);
			Assert.AreEqual ("Invalid placement, robot cannot move there", robot.error);
			Assert.AreEqual ("5, 5, North", robot.GetRobotPosition ());
		}

		[Test ()]
		public void shouldReportRobotPositionWhenCorrectlyPlacedOnTheGrid ()
		{
			var robot = new Robot ();
			var result = robot.PlaceRobot (2, 1, DirectionFacing.West);
			var position = robot.GetRobotPosition ();
			Assert.IsTrue (result);
			Assert.AreEqual ("", robot.error);
			Assert.AreEqual ("2, 1, West", position);
		}

		[Test ()]
		public void robotShouldReportCorrectPositionWhenTurnedRight ()
		{
			var robot = new Robot ();
			var result = robot.PlaceRobot (1, 1, DirectionFacing.South);
			robot.TurnRight ();
			Assert.IsTrue (result);
			Assert.AreEqual ("1, 1, West", robot.GetRobotPosition ());

		}

		[Test ()]
		public void robotShouldReportCorrectPositionWhenTurnedLeft()
		{
			var robot = new Robot ();
			var result = robot.PlaceRobot (1, 1, DirectionFacing.South);
			robot.TurnLeft ();
			Assert.IsTrue (result);
			Assert.AreEqual ("1, 1, East", robot.GetRobotPosition ());
		}



		[Test ()]
		public void robotShouldMoveAndReportPositionCorrectly()
		{
			var robot = new Robot ();
			robot.PlaceRobot (1, 1, DirectionFacing.West);
			var result = robot.Move ();
			Assert.IsTrue (result);
			Assert.AreEqual ("0, 1, West", robot.GetRobotPosition ());
		}
	
		[Test ()]
		public void robotShouldMoveAndTurnAndReportItsPosition()
		{
			var robot = new Robot ();
			robot.PlaceRobot (1, 1, DirectionFacing.East);
			robot.Move ();
			robot.TurnLeft ();
			robot.Move ();
			robot.Move ();
			Assert.AreEqual ("2, 3, North", robot.GetRobotPosition ());
		}
	}
}

