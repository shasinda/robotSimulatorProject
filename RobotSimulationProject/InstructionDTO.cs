using System;

namespace RobotSimulationProject
{
	public class InstructionDTO : ICommand
	{
		public int xPosition { get; set;}
		public int yPosition { get; set;}
		public DirectionFacing dFacing { get; set;}
	}
}

