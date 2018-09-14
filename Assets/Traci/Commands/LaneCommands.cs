using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class LaneCommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all lanes within the scenario (the given Lane ID is ignored)
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

        /// <summary>
        /// Returns the number of lanes within the scenario (the given Lane ID is ignored)
        /// </summary>
        /// <returns></returns>
		public async Task<TraCIResponse<int>> GetIdCount()
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

        /// <summary>
        /// Returns the number of links outgoing from this lane [#]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<byte>> GetLinkNumber(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<byte>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINK_NUMBER);
		}

        /// <summary>
        /// Returns the id of the edge this lane belongs to
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<string>> GetEdgeId(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_EDGE_ID);
		}

        /// <summary>
        /// Returns descriptions of the links outgoing from this lane [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<CompoundObject>> GetLinks(string id)
		{
            //TODO: parse the result into a usable format
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<CompoundObject>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINKS);
		}

        /// <summary>
        /// Returns the mml-definitions of vehicle classes allowed on this lane
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<List<string>>> GetAllowed(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_ALLOWED);
		}

        /// <summary>
        /// Returns the mml-definitions of vehicle classes not allowed on this lane
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<List<string>>> GetDisallowed(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_DISALLOWED);
		}

        /// <summary>
        /// Returns the length of the named lane [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetLength(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

        /// <summary>
        /// Returns the maximum speed allowed on this lane [m/s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetMaxSpeed(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

        /// <summary>
        /// Returns this lane's shape
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<Polygon>> GetShape(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Polygon>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_SHAPE);
		}

        /// <summary>
        /// Returns the width of the named lane [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetWidth(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

        /// <summary>
        /// Sum of CO2 emissions on this lane in mg during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetCO2Emission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}

        /// <summary>
        /// Sum of CO emissions on this lane in mg during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetCOEmission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}

        /// <summary>
        /// Sum of HC emissions on this lane in mg during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetHCEmission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}

        /// <summary>
        /// Sum of PMx emissions on this lane in mg during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetPMxEmission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}

        /// <summary>
        /// Sum of NOx emissions on this lane in mg during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetNOxEmission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}

        /// <summary>
        /// Sum of fuel consumption on this lane in ml during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetFuelConsumption(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}

        /// <summary>
        /// Sum of noise generated on this lane in dBA.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetNoiseEmission(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}

        /// <summary>
        /// Sum of electricity consumption on this lane in kWh during this time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetElectricityConsumption(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}

        /// <summary>
        /// The number of vehicles on this lane within the last time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<int>> GetLastStepVehicleNumber(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

        /// <summary>
        /// Returns the mean speed of vehicles that were on this lane within the last simulation step [m/s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetLastStepMeanSpeed(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

        /// <summary>
        /// Returns the list of ids of vehicles that were on this lane in the last simulation step
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<List<string>>> GetLastStepVehicleIds(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

        /// <summary>
        /// Returns the total lengths of vehicles on this lane during the last simulation step divided by the length of this lane
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetLastStepOccupancy(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

        /// <summary>
        /// The mean length of vehicles which were on this lane in the last step [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetLastStepLength(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

        /// <summary>
        /// Returns the waiting time for all vehicles on the lane [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetWaitingTime(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

        /// <summary>
        /// Returns the estimated travel time for the last time step on the given lane [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public async Task<TraCIResponse<double>> GetTravelTime(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CURRENT_TRAVELTIME);
		}

        /// <summary>
        /// Returns the total number of halting vehicles for the last time step on the given lane.
        /// A speed of less than 0.1 m/s is considered a halt.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetLastStepHaltingNumber(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}

        /// <summary>
        /// Sets a list of allowed vehicle classes.
        /// </summary>
        public async Task<TraCIResponse<object>> SetAllowed(string laneId, List<string> allowedVehicleClasses)
        {
            return await
                TraCICommandHelper.ExecuteSetCommandAsync<object, List<string>>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.LANE_ALLOWED,
                allowedVehicleClasses);
        }

        /// <summary>
        /// Sets a list of disallowed vehicle classes.
        /// </summary>
        public async Task<TraCIResponse<object>> SetDisallowed(string laneId, List<string> disallowedVehicleClasses)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, List<string>>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.LANE_DISALLOWED,
                disallowedVehicleClasses);
        }

        /// <summary>
        /// Sets the length of the lane in m
        /// </summary>
        public async Task<TraCIResponse<object>> SetLength(string laneId, double length)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.VAR_LENGTH,
                length);
        }

        /// <summary>
        /// Sets a new maximum allowed speed on the lane in m/s.
        /// </summary>
        public async Task<TraCIResponse<object>> SetMaxSpeed(string laneId, double maxSpeed)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.VAR_MAXSPEED,
                maxSpeed);
        }



        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_LANE_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public LaneCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}