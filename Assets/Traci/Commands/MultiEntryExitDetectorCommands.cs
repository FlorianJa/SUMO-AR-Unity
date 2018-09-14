using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class MultiEntryExitDetectorCommands : TraCICommandsBase
	{
        #region Public Methods

        /// <summary>
        /// Returns a list of all objects in the network.
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
		{
			return await
				TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_LIST);
		}

        /// <summary>
        /// Returns the number of currently loaded objects.
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetIdCount()
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

        /// <summary>
        /// Returns the number of vehicles that have been within the named multi-entry/multi-exit detector within the
        /// last simulation step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetLastStepVehicleNumber(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

        /// <summary>
        /// Returns the mean speed in m/s of vehicles that have been within the named multi-entry/multi-exit detector
        /// within the last simulation step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetLastStepMeanSpeed(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

        /// <summary>
        /// Returns the list of ids of vehicles that have been within the named multi-entry/multi-exit detector in the
        /// last simulation step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetLastStepVehicleIds(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

        /// <summary>
        /// Returns the number of vehicles which were halting during the last time step.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetLastStepHaltingNumber(string id)
		{
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}


        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_MULTIENTRYEXIT_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public MultiEntryExitDetectorCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}