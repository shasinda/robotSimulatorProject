using System;

namespace RobotSimulationProject
{
	public class RobotSimulator
	{
		public RobotSimulator (Robot robot)
		{
			this.Robot = robot;
		}

		public Robot Robot { get; set;}


		public string Action(string action)
		{
			string response = "";
			ICommand args = null;
			var instruction = GetCommandInstructions(action, ref args);

			switch (instruction)
			{
			case RobotInstruction.Place:
				var placeArgs = (InstructionDTO)args;
				if (Robot.PlaceRobot(placeArgs.xPosition, placeArgs.yPosition, placeArgs.dFacing))
				{
					response = "Success.";
				}
				else
				{
					response = Robot.error;
				}
				break;
			case RobotInstruction.Move:
				if (Robot.Move())
				{
					response = "Success.";
				}
				else
				{
					response = Robot.error;
				}
				break;
			case RobotInstruction.Left:
				if (Robot.TurnLeft())
				{
					response = "Success.";
				}
				else
				{
					response = Robot.error;
				}
				break;
			case RobotInstruction.Right:
				if (Robot.TurnRight())
				{
					response = "Success.";
				}
				else
				{
					response = Robot.error;
				}
				break;
			case RobotInstruction.Report:
				response = Robot.GetRobotPosition();
				break;
			default:
				response = "Invalid action.";
				break;
			}
			return response;            
		}

		private RobotInstruction GetCommandInstructions(string action, ref ICommand args)
		{
			RobotInstruction result;
			string stringArg = "";

			int argsSeperatorPosition = action.IndexOf(" ");
			if (argsSeperatorPosition > 0)
			{
				stringArg = action.Substring(argsSeperatorPosition + 1);
				action = action.Substring(0, argsSeperatorPosition);
			}
			action = action.ToUpper();

			if (Enum.TryParse<RobotInstruction>(action, true, out result))
			{
				if (result == RobotInstruction.Place)
				{
					if (!ParseArgs(stringArg, ref args))
					{
						result = RobotInstruction.Invalid;
					}
				}
			}
			else
			{
				result = RobotInstruction.Invalid;
			}
			return result;
		}

		private bool ParseArgs(string argString, ref ICommand args)
		{
			var argParts = argString.Split(','); 
			int x, y;
			DirectionFacing directionFacing;

			if (argParts.Length == 3 &&
				TryGetCoordinate(argParts[0], out x) &&
				TryGetCoordinate(argParts[1], out y) &&
				TryGetFacingDirection(argParts[2], out directionFacing))
			{
				args = new InstructionDTO
				{
					xPosition = x,
					yPosition = y,
					dFacing = directionFacing,
				};
				return true;
			}
			return false;            
		}

		private bool TryGetCoordinate(string coordinate, out int coordinateValue)
		{
			return int.TryParse(coordinate, out coordinateValue);
		}

		private bool TryGetFacingDirection(string direction, out DirectionFacing facing)
		{
			return Enum.TryParse<DirectionFacing>(direction, true, out facing);
		}
	}    
	}


