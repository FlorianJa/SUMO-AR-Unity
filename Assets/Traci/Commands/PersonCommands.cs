using System.Collections.Generic;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
    public class PersonCommands : TraCICommandsBase
    {
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all persons currently running within the scenario (the given person ID is ignored)
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.ID_LIST);
        }

        /// <summary>
        /// 	Returns the number of persons currently running within the scenario (the given person ID is ignored)
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetIdCount()
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.ID_COUNT);
        }

        /// <summary>
        /// 	Returns the speed of the named person within the last step [m/s]; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetSpeed(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_SPEED);
        }

        /// <summary>
        /// /	Returns the position(two doubles) of the named person within the last step [m,m]; error value: [-2^30, -2^30].
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<Position2D>> GetPosition(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_POSITION);
        }

        /// <summary>
        /// /Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m]; error value: [-2^30, -2^30, -2^30].
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<Position3D>> GetPosition3D(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Position3D>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_POSITION3D);
        }

        /// <summary>
        /// Returns the angle of the named person within the last step [°]; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetAngle(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_ANGLE);
        }

        /// <summary>
        /// 	Returns the id of the edge the named person was at within the last step; error value: ""
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetRoadID(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_ROAD_ID);
        }

        /// <summary>
        /// 	Returns the id of the type of the named person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetTypeID(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_TYPE);
        }

        /// <summary>
        /// 	Returns the person's color.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<Color>> GetColor(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_COLOR);
        }

        /// <summary>
        /// The position of the person along the edge (in [m]); error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetLanePosition(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_LANEPOSITION);
        }

        /// <summary>
        /// Returns the length of the persons [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetLength(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_LENGTH);
        }

        /// <summary>
        /// Returns the offset (gap to front person if halting) of this person [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetMinGap(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_MINGAP);
        }

        /// <summary>
        /// Returns the width of this person [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetWidth(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_WIDTH);
        }

        /// <summary>
        /// Returns the waiting time [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetWaitingTime(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_WAITING_TIME);
        }

        /// <summary>
        /// Returns the next edge on the persons route while it is walking. If there is no further edge or the person is in another stage, returns the empty string.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetNextEdge(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_NEXT_EDGE);
        }

        /// <summary>
        /// Returns the number of remaining stages for the given person including the current stage.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetRemainingStages(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_STAGES_REMAINING);
        }

        /// <summary>
        /// Returns the id of the vehicle if the person is in stage driving and has entered a vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetVehicle(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_PERSON_VARIABLE,
                    TraCIConstants.VAR_VEHICLE);
        }

        // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Person_Value_Retrieval

        /// <summary>
        /// 	Inserts a new person to the simulation at the given edge, position and time (in s). This function should be followed by appending Stages or the person will immediately vanish on departure.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId"></param>
        /// <param name="initialEdgeId"></param>
        /// <param name="departTime"></param>
        /// <param name="departPosition"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> Add(string id, string typeId, string initialEdgeId, int departTime, double departPosition)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = typeId });
            tmp.Value.Add(new TraCIString() { Value = initialEdgeId });
            tmp.Value.Add(new TraCIInteger() { Value = departTime });
            tmp.Value.Add(new TraCIDouble() { Value = departPosition });

            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_PERSON_VARIABLE,
                     TraCIConstants.ADD,
                     tmp
                     );
        }

        /// <summary>
        /// Appends a stage driving to the plan of the given person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="destination"></param>
        /// <param name="lines"></param>
        /// <param name="stopId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> AppendDrivingStage(string id, string destination, string lines, string stopId)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 3 });
            tmp.Value.Add(new TraCIString() { Value = destination });
            tmp.Value.Add(new TraCIString() { Value = lines });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        /// <summary>
        /// 	Appends a stage waiting to the plan of the given person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="description"></param>
        /// <param name="stopId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> AppendWaitingStage(string id, int duration, string description, string stopId)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 1 });
            tmp.Value.Add(new TraCIInteger() { Value = duration });
            tmp.Value.Add(new TraCIString() { Value = description });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        /// <summary>
        /// 	Appends a stage walking to the plan of the given person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edges"></param>
        /// <param name="arrivalPosition"></param>
        /// <param name="duration"></param>
        /// <param name="speed"></param>
        /// <param name="stopId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> AppendWalkingStage(string id, List<string> edges, double arrivalPosition, int duration, double speed, string stopId)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 2 });
            tmp.Value.Add(new TraCIStringList() { Value = edges });
            tmp.Value.Add(new TraCIDouble() { Value = arrivalPosition });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        /// <summary>
        /// Removes the nth next stage. nextStageIndex must be lower then value of getRemainingStages(personID). nextStageIndex 0 immediately aborts the current stage and proceeds to the next stage. When removing all stages, stage 0 should be removed last
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stageIndex"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> RemoveStage(string id, int stageIndex)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.ADD,
                stageIndex
                );
        }

        /// <summary>
        /// Computes a new route to the current destination that minimizes travel time. The assumed values for each edge in the network can be customized in various ways.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> RerouteTraveltime(string id)
        {

            return await TraCICommandHelper.ExecuteSetCommandAsync<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.CMD_REROUTE_TRAVELTIME,
                new CompoundObject()
                );
        }

        /// <summary>
        /// Sets color for person with the given ID. i.e. (255,0,0,255) for the color red.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetColor(string id, Color color)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, Color>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_COLOR,
                color
                );
        }

        /// <summary>
        /// Sets the height in m for this person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetHeight(string id, double height)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_HEIGHT,
                height
                );
        }

        /// <summary>
        /// Sets the length in m for the given person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetLength(string id, double length)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.ADD,
                length
                );
        }

        /// <summary>
        /// Sets the offset (gap to front person if halting) for this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="minGap"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetMinGap(string id, double minGap)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_MINGAP,
                minGap
                );
        }

        /// <summary>
        /// Sets the maximum speed in m/s for the named person for subsequent step.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetSpeed(string id, double speed)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_SPEED_FACTOR,
                speed
                );
        }

        /// <summary>
        /// Sets the id of the type for the named person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetType(string id, string typeId)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_TYPE,
                typeId
                );
        }

        /// <summary>
        /// Sets the width in m for this person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetWidth(string id, double width)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_WIDTH,
                width
                );
        }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_PERSON_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public PersonCommands(TraCIClient client) : base(client)
        {
        }

        #endregion // Constructor
    }
}