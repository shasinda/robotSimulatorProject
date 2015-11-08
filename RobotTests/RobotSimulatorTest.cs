using System;
using RobotSimulationProject;
using NUnit.Framework;

namespace RobotSimulationProject.Tests
{
	[TestFixture ()]
	public class RobotSimulatorTest
	{
		[Test ()]
		public void robotSimulatorShouldRaiseAnErrorWhenTheCommandIsInvalid()
		{
			var robotSim = new RobotSimulator(new Robot());
			var result = robotSim.Action ("");
			Assert.AreEqual ("Invalid action.", result);
			result = robotSim.Action ("InvalidCommand");
			Assert.AreEqual ("Invalid action.", result);
		}

		[Test ()]
		public void robotSimulatorShouldReturnValidResultsWhenActionIsValid()
		{
			var robotSim = new RobotSimulator (new Robot ());
			var result = robotSim.Action ("MOVE");
			Assert.AreEqual ("Robot cannot move until it has been properly placed", result);
		}

		[Test ()]
		public void robotShouldAcceptValidCommandsFromSimulator()
		{
			var robotSim = new RobotSimulator (new Robot ());
			robotSim.Action ("PLACE 1,1,EAST");
			robotSim.Action ("LEFT");
			Assert.AreEqual ("1, 1, North", robotSim.Action ("REPORT"));
		}

		[Test ()]
		public void robotSimulatorShouldPlaceMoveAndTurnTheRobot()
		{
			var robotSim = new RobotSimulator (new Robot ());
			robotSim.Action ("PLACE 1,1,EAST");
			robotSim.Action ("MOVE");
			robotSim.Action ("LEFT");
			robotSim.Action ("MOVE");
			robotSim.Action ("MOVE");
			Assert.AreEqual ("2, 3, North", robotSim.Action ("REPORT"));
		}
	}
}

