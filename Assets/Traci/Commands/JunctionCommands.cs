﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class JunctionCommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all junctions within the scenario 
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.ID_LIST);
		}

        /// <summary>
        /// Returns the number of junctions within the scenario
        /// </summary>
        /// <returns></returns>
		public async Task<TraCIResponse<int>> GetIdCount()
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

        /// <summary>
        /// Returns the position of the named junction [m,m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Position2D>> GetPosition(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

        /// <summary>
        /// Returns the shape (list of 2D-positions) of the named junction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Polygon>> GetShape(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Polygon>(
				Client,
				id,
				TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
				TraCIConstants.VAR_SHAPE);
		}


        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_JUNCTION_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public JunctionCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}
