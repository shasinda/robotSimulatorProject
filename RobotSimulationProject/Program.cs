using System;

namespace RobotSimulationProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine("Robit Simulator");
			Console.WriteLine("---------------------------------------");
			Console.WriteLine("---------------------------------------");
			Console.WriteLine ("Enter an action to simulate the robot. or type 'Exit' to quit the program.");

			var robotSim = new RobotSimulator (new Robot ());

			while (true) 
			{
				string action = ReadUserInput ();

				if (action.Equals ("Exit")) 
				{
					Environment.Exit (0);
				}
				Console.WriteLine (robotSim.Action (action));				
			}
		}

		private static string ReadUserInput()
		{
			Console.WriteLine ("Enter Action: ");
			return Console.ReadLine ();
		}

	}
}
