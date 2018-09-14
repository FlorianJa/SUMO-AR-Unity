using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;
using System;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Commands
{
    public class VehicleTypeCommands : TraCICommandsBase
    {
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of currently loaded vehicle types 
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<List<string>>> GetIdList()
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<List<string>>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.ID_LIST);
        }

        /// <summary>
        /// Returns the number of currently loaded vehicle types
        /// </summary>
        /// <returns></returns>
        public async Task<TraCIResponse<int>> GetIdCount()
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<int>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.ID_COUNT);
        }

        /// <summary>
        /// Returns the length of the vehicles of this type [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetLength(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_LENGTH);
        }

        /// <summary>
        /// Returns the maximum speed of vehicles of this type [m/s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetMaxSpeed(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED);
        }

        /// <summary>
        /// Returns the maximum acceleration possibility of vehicles of this type [m/s^2]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetAccel(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_ACCEL);
        }

        /// <summary>
        /// Returns the maximum deceleration possibility of vehicles of this type [m/s^2]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetDecel(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_DECEL);
        }

        /// <summary>
        /// Returns the driver's desired time headway for vehicles of this type [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetTau(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_TAU);
        }

        /// <summary>
        /// Returns the driver's imperfection (dawdling) [0,1]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetImperfection(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_IMPERFECTION);
        }

        /// <summary>
        /// Returns the road speed multiplier for drivers of this type [double]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetSpeedFactor(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SPEED_FACTOR);
        }

        /// <summary>
        /// Returns the deviation of speedFactor for drivers of this type [double]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetSpeedDeviation(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SPEED_DEVIATION);
        }

        /// <summary>
        /// Returns the class of vehicles of this type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetVehicleClass(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_VEHICLECLASS);
        }

        /// <summary>
        /// Returns the emission class of vehicles of this type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetEmissionClass(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_EMISSIONCLASS);
        }

        /// <summary>
        /// Returns the shape of vehicles of this type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetShapeClass(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SHAPECLASS);
        }

        /// <summary>
        /// Returns the offset (gap to front vehicle if halting) of vehicles of this type [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetMinGap(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MINGAP);
        }

        /// <summary>
        /// Returns the width of vehicles of this type [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetWidth(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_WIDTH);
        }

        /// <summary>
        /// Returns the height of vehicles of this type [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetHeight(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_HEIGHT);
        }

        /// <summary>
        /// Returns the color of this type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<Color>> GetColor(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_COLOR);
        }

        /// <summary>
        /// Returns the maximum lateral speed in m/s of this type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetMaxSpeedLat(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED_LAT);
        }

        /// <summary>
        /// Returns the desired lateral gap of this type at 50km/h in m.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetMinGapLat(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MINGAP_LAT);
        }

        /// <summary>
        /// Returns the preferred lateral alignment of the type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<string>> GetLateralAlignment(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_LATALIGNMENT);
        }

        /// <summary>
        /// Returns the action step length for the vehicle type in s.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<double>> GetActionStepLength(string id)
        {
            return await
                TraCICommandHelper.ExecuteGetCommandAsync<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
#warning Check this
                    TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
        }

        /// <summary>
        /// Sets the vehicle type's length to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetLength(string id, double length)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LENGTH,
                    length
                    );
        }

        /// <summary>
        /// Sets the vehicle type's maximum speed to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetMaxSpeed(string id, double speed)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED,
                    speed
                    );
        }

        /// <summary>
        /// Sets the vehicle type's vehicle class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleClass"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetVehicleClass(string id, string vehicleClass)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_VEHICLECLASS,
                    vehicleClass
                    );
        }

        /// <summary>
        /// Sets the vehicle type's speed factor to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speedFactor"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetSpeedFactor(string id, double speedFactor)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_FACTOR,
                    speedFactor
                    );
        }

        /// <summary>
        /// Sets the vehicle type's speed deviation to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speedDeviation"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetSpeedDeviation(string id, double speedDeviation)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_DEVIATION,
                    speedDeviation
                    );
        }

        /// <summary>
        /// Sets the vehicle type's emission class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emissionClass"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetEmissionClass(string id, string emissionClass)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_EMISSIONCLASS,
                    emissionClass
                    );
        }

        /// <summary>
        /// Sets the vehicle type's width to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetWidth(string id, double width)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_WIDTH,
                    width
                    );
        }

        /// <summary>
        /// Sets the vehicle type's height to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetHeight(string id, double height)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_HEIGHT,
                    height
                    );
        }

        /// <summary>
        /// Sets the vehicle type's minimum headway gap to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="minGap"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetMinGap(string id, double minGap)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MINGAP,
                    minGap
                    );
        }

        /// <summary>
        /// Sets the vehicle type's shape class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shapeClass"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetShapeClass(string id, string shapeClass)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SHAPECLASS,
                    shapeClass
                    );
        }

        /// <summary>
        /// Sets the vehicle type's wished maximum acceleration to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acceleration"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetAccel(string id, double acceleration)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ACCEL,
                    acceleration
                    );
        }

        /// <summary>
        /// Sets the vehicle type's wished maximum deceleration to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="decceleration"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetDecel(string id, double decceleration)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_DECEL,
                    decceleration
                    );
        }

        /// <summary>
        /// Sets the vehicle type's driver imperfection (sigma) to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imperfection"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetImperfection(string id, double imperfection)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_IMPERFECTION,
                    imperfection
                    );
        }

        /// <summary>
        /// Sets the vehicle type's wished headway time to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetTau(string id, double tau)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_TAU,
                    tau
                    );
        }

        /// <summary>
        /// Sets the vehicle type's color.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetColor(string id, Color color)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_COLOR,
                    color
                    );
        }

        /// <summary>
        /// Sets the maximum lateral speed in m/s of this type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetMaxSpeedLat(string id, double maxSpeed)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED_LAT,
                    maxSpeed
                    );
        }

        /// <summary>
        /// Sets the minimal lateral gap of this type at 50km/h in m.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="minGap"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetMinGapLat(string id, double minGap)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MINGAP_LAT,
                    minGap
                    );
        }

        /// <summary>
        /// Sets the preferred lateral alignment of the type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> SetLateralAlignment(string id, string alignment)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LATALIGNMENT,
                    alignment
                    );
        }

        /// <summary>
        /// Creates a new vehicle type with the given ID as a duplicate of the original type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newId"></param>
        /// <returns></returns>
        public async Task<TraCIResponse<object>> Copy(string id, string newId)
        {
            return await TraCICommandHelper.ExecuteSetCommandAsync<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.COPY,
                    newId
                    );
        }

        /// <summary>
        /// Sets the current action step length for the vehicle type in s. If the boolean value resetActionOffset is true, an action step is scheduled immediately for all vehicles of the type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetActionStepLengt(string id)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
            TraCICommandHelper.ExecuteSubscribeCommandAsync(
                Client,
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_VEHICLETYPE_VARIABLE,
                ListOfVariablesToSubsribeTo);
        }
        #endregion // Public Methods

        #region Constructor

        public VehicleTypeCommands(TraCIClient client) : base(client)
        {
        }

        #endregion // Constructor
    }
}