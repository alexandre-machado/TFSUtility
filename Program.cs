﻿using System;
using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TFSUtility.Factories;

namespace TFSUtility
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine();
            Console.WriteLine();

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: TFSUtility command:<command> [<options>|help]");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Availiable commands:");
                Console.WriteLine("   map       Map completed work of Users x Dates");
                Console.WriteLine();
            }

            var parameters = ParameterFactory.GetParameters(args);

            try
            {
                switch (parameters.Command)
                {
                    case Parameters.MAPWORK_COMMAND:
                        var command = CommandFactory.GetMapWork(parameters);
                        command.Execute(Console.Out);

                        break;
                }
            }
            catch(TeamFoundationServiceUnavailableException e)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            catch (ValidationException e)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
        }
    }
}
