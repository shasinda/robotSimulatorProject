using System;

namespace RobotSimulationProject
{
	//Robot class apply given instructions to simulate the robot
	public class Robot
	{
		public Robot ()
		{
			error = "";
		}

		private int? _xPosition;
		private int? _yPosition;

		private DirectionFacing _directionFacing;

		public string error { get; set;}

		private const int GRID_SIZE = 5;

		/**
		 * Place the robot on the grid.
		 */
		public bool PlaceRobot(int x, int y, DirectionFacing facing)
		{
			if (validateRobotPlacement (x, y, "place")) 
			{
				_xPosition = x;
				_yPosition = y;
				_directionFacing = facing;
				return true;
			}
			return false;
		}

		/**
		 * Move the robot on the x axis and returns its moved position.
		 */
		private int GetMovedXPosition()
		{
			if (_directionFacing == DirectionFacing.East) 
			{
				return _xPosition + 1;
			} 
			else 
			{	
				if (_directionFacing == DirectionFacing.West) 
				{
					return _xPosition - 1;
				}
			
			}
			return _xPosition;
		}

		/**
		 * Move the robot on the y axis and returns its moved position.
		 */
		private int GetMovedYPosition()
		{
			if (_directionFacing == DirectionFacing.North) 
			{
				return _yPosition + 1;
			} 
			else 
			{
				if (_directionFacing == DirectionFacing.South) 
				{
					return _yPosition - 1;
				}
			}
		}

		/**
		 * Move the robot in the X or Y axis according to the direction setting.
		 */ 
		public bool Move()
		{
			if (IsRobotActionValid ("move")) 
			{
				int newXPosition = GetMovedXPosition ();
				int newYPosition = GetMovedYPosition ();

				if (validateRobotPlacement (newXPosition, newYPosition, "move")) 
				{
					_xPosition = newXPosition;
					_yPosition = newYPosition;
					return true;
				}
			}
			return false;
		}

		/**
		 *Turn the robot in the given direction
		 */ 
		private bool Turn(Direction direction)
		{
			if (IsRobotActionValid ("turn")) 
			{
				var facingDirctionValue = (int)_directionFacing;
				facingDirctionValue += 1 * (direction == Direction.Right ? 1 : -1);
				if (facingDirctionValue = 5)
					facingDirctionValue = 1;
				if (facingDirctionValue = 0)
					facingDirctionValue = 4;
				_directionFacing = (DirectionFacing)facingDirctionValue;
				return true;
			}
			return false;
		}

		/**
		 * Returns whether the robot is placed properly in the grid, before applying action to it
		 */
		private bool IsRobotActionValid(string action)
		{
			if (!_xPosition.HasValue || !_yPosition.HasValue) 
			{
				error = String.Format ("Robot cannot be {0} until it has been properly placed", action);
				return false;
			} 
			return true;
		}

		/**
		 * Validate the placement of the robot, whether it has been placed within the limits of the grid.
		 */
		private bool validateRobotPlacement(int x, int y, string action)
		{
			if (x < 0 || y < 0 || x >= GRID_SIZE || y >= GRID_SIZE) 
			{
				error = String.Format ("Invalid placement, robot cannot be {0} there", action);
				return false;
			}
			return true;
		}
	}	
}

