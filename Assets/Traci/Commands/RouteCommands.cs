using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class RouteCommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all currently loaded routes
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

        /// <summary>
        /// Returns the number of currently loaded routes
        /// </summary>
        /// <returns></returns>
		public async Task<TraCIResponse<int>> GetIdCount()
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

        /// <summary>
        /// Returns the ids of the edges this route covers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<List<string>>> GetEdges(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.VAR_EDGES);
		}

        /// <summary>
        /// Adds a new route; the route gets the given id and follows the given edges.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> Add(string id, List<string> edges)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, List<string>>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_ROUTE_VARIABLE,
                    TraCIConstants.ADD,
                    edges
                    );
        }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_ROUTE_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public RouteCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

