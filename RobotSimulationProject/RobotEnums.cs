using System;

namespace RobotSimulationProject
{

	public enum Direction : int{
		Left = 1,
		Right = -1,
	}

	public enum RobotInstruction : int{
		Invalid = 0,
		Place = 1,
		Move = 2,
		Left = 3,
		Right = 4,
		Report = 5,
	}

	public enum DirectionFacing: int{
		North = 1,
		East = 2,
		South = 3,
		West = 4,
	}


}

