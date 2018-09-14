using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class POICommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all poi
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_LIST);
		}

        /// <summary>
        /// Returns the number of pois
        /// </summary>
        /// <returns></returns>
		public async Task<TraCIResponse<int>> GetIdCount()
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

        /// <summary>
        /// Returns the (abstract) type of the poi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<string>> GetType(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

        /// <summary>
        /// Returns the color of this poi 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Color>> GetColor(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

        /// <summary>
        /// Returns the position of this poi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Position2D>> GetPosition(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_POI_VARIABLE,
				TraCIConstants.VAR_POSITION);
		}

        /// <summary>
        /// Sets the PoI's type to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetType(string id, string type)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_TYPE,
                    type
                    );
        }

        /// <summary>
        /// Sets the PoI's color to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetColor(string id, Color color)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_COLOR,
                    color
                    );
        }

        /// <summary>
        /// Sets the PoI's position to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position2D"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetPosition(string id, Position2D position2D)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_POSITION,
                    position2D
                    );
        }

        /// <summary>
        /// Adds the defined PoI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="layer"></param>
        /// <param name="position2D"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> Add(string id, string name, Color color, int layer, Position2D position2D)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = name });
            tmp.Value.Add(color);
            tmp.Value.Add(new TraCIInteger() { Value = layer });
            tmp.Value.Add(position2D);
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.ADD,
                    tmp
                    );
        }

        /// <summary>
        /// Removes the defined PoI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> Remove(string id, int layer)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, int>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.REMOVE,
                    layer
                    );
        }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_POI_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public POICommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

