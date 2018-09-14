using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class GuiCommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// the current zoom level (in %)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetZoom(string id)
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_ZOOM);
		}

        /// <summary>
        /// the center of the currently visible part of the net
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Position2D>> GetOffset(string id)
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_OFFSET);
		}

        /// <summary>
        /// the visualization scheme used (e.g. "standard" or "real world")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<string>> GetSchema(string id)
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_SCHEMA);
		}

        /// <summary>
        /// the lower left and the upper right corner of the visible network
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<BoundaryBox>> GetBoundary(string id)
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<BoundaryBox>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_BOUNDARY);
		}

        /// <summary>
        /// 	Sets the current zoom level in %
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetZoom(string id, double zoom)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_ZOOM,
                    zoom
                    );
        }

        /// <summary>
        /// Moves the center of the visible network to the given position
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetOffset(string id, Position2D position)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_OFFSET,
                    position
                    );
        }

        /// <summary>
        /// Sets the visualization scheme (e.g. "standard")
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetSchema(string id, string schema)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_SCHEMA,
                    schema
                    );
        }

        /// <summary>
        /// Moves the center of the visible network to the given position
        /// </summary>
        /// <param name="id"></param>
        /// <param name="boundaryBox"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetBoundary(string id, BoundaryBox boundaryBox)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, BoundaryBox>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_BOUNDARY,
                    boundaryBox
                    );
        }

        /// <summary>
        /// Save a screenshot to the given file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> screenshot(string id, string filename)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_SCREENSHOT,
                    filename
                    );
        }

        /// <summary>
        /// tracks the given vehicle in the GUI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> TrackVehicle(string id, string vehicleId)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_TRACK_VEHICLE,
                    vehicleId
                    );
        }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_GUI_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public GuiCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

