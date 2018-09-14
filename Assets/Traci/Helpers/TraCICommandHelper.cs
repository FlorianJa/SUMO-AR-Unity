using CodingConnected.TraCI.NET.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Helpers
{
	internal static class TraCICommandHelper
	{
        internal async static Task<TraCIResponse<Tres>> ExecuteSetCommandAsync<Tres, Tvalue>(TraCIClient client, string id, byte commandType, byte messageType, Tvalue value)
        {
            TraCICommand command = null;

            if (value is byte)
            {
                byte b = Convert.ToByte(value);
                command = GetCommand(id, commandType, messageType, b);
            }
            else if( value is Int32)
            {
                int i = Convert.ToInt32(value);
                command = GetCommand(id, commandType, messageType, i);
            }
            else if(value is Double)
            {
                double d = Convert.ToDouble(value);
                command = GetCommand(id, commandType, messageType, d);
            }
            else if (value is String)
            {
                string s = value as string;
                command = GetCommand(id, commandType, messageType, s);
            }
            else if (value is List<string>)
            {
                List<string> los = value as List<string>;
                command = GetCommand(id, commandType, messageType, los);
            }
            else if(value is CompoundObject)
            {
                CompoundObject co = value as CompoundObject;
                command = GetCommand(id, commandType, messageType, co);
            }
            else if(value is Color)
            {
                Color c = value as Color;
                command = GetCommand(id, commandType, messageType, c);
            }
            else if(value is Position2D)
            {
                Position2D p2d = value as Position2D;
                command = GetCommand(id, commandType, messageType, p2d);
            }
            else if(value is Polygon)
            {
                Polygon p = value as Polygon;
                command = GetCommand(id, commandType, messageType, p);
            }
            else if(value is BoundaryBox)
            {
                BoundaryBox bb = value as BoundaryBox;
                command = GetCommand(id, commandType, messageType, bb);
            }
            else
            {
                throw new InvalidCastException($"Type {value.GetType().Name} is not implemented in method TraCICommandHelper.ExecuteSetCommand().");
            }

            if (command != null)
            {
                var response = await client.SendMessageAsync(command);

                try
                {
                    return TraCIDataConverter.ExtractDataFromResponse<Tres>(response, commandType, messageType);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                return default(TraCIResponse<Tres>);
            }
        }

        internal static void ExecuteSubscribeCommandAsync(TraCIClient client, int beginTime, int endTime, string objectId, byte commandType, List<byte> variables)
        {
            TraCICommand command = null;
            command = GetCommand(objectId, beginTime, endTime, commandType, variables);
            var response = client.SendMessageAsync(command);

            //try
            //{
            //    var tmp = TraCIDataConverter.ExtractDataFromResponse<T>(response, commandType);
            //}
            //catch
            //{
            //    throw;
            //}
        }

        internal async static Task<TraCIResponse<T>> ExecuteGetCommandAsync<T>(TraCIClient client, string id, byte commandType, byte messageType)
        {
            var command = GetCommand(id, commandType, messageType);
            var response = await client.SendMessageAsync(command);

            try
            {
                return TraCIDataConverter.ExtractDataFromResponse<T>(response, commandType, messageType); 
            }
            catch
            {
                throw;
            }
        }

        internal static TraCICommand GetCommand(string objectId, int beginTime, int endTime, byte commandType, List<byte> variables)
        {
            var bytes = new List<byte>();
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(beginTime));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(endTime));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(objectId));
            bytes.Add((byte)variables.Count);
            foreach (var variable in variables)
            {
                bytes.Add(variable);
            }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, CompoundObject co)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COMPOUND);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(co.Value.Count));
            foreach (var item in co.Value)
            {
                if (item is TraCIByte)
                {
                    TraCIByte b = item as TraCIByte;
                    bytes.Add(TraCIConstants.TYPE_BYTE);
                    bytes.Add(b.Value);
                }
                else if (item is TraCIUByte)
                {
                    TraCIUByte ub = item as TraCIUByte;
                    bytes.Add(TraCIConstants.TYPE_UBYTE);
                    bytes.Add(ub.Value);
                }
                else if (item is TraCIInteger)
                {
                    TraCIInteger i = item as TraCIInteger;
                    bytes.Add(TraCIConstants.TYPE_INTEGER);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(i.Value));
                }
                else if (item is TraCIFloat)
                {
                    TraCIFloat f = item as TraCIFloat;
                    bytes.Add(TraCIConstants.TYPE_FLOAT);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromFloat(f.Value));
                }
                else if (item is TraCIDouble)
                {
                    TraCIDouble d = item as TraCIDouble;
                    bytes.Add(TraCIConstants.TYPE_DOUBLE);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(d.Value));

                }
                else if (item is TraCIString)
                {
                    TraCIString s = item as TraCIString;
                    bytes.Add(TraCIConstants.TYPE_STRING);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(s.Value));
                }
                else if (item is TraCIStringList)
                {
                    TraCIStringList sl = item as TraCIStringList;
                    bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIStringList(sl.Value));
                }
                else if (item is CompoundObject)
                {
                    throw new NotImplementedException("Nested compound objects are not implemented yet");
                }
                else if (item is Position2D)
                {
                    Position2D p2d = item as Position2D;
                    bytes.Add(TraCIConstants.POSITION_2D);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPosition2D(p2d));
                }
                else if (item is Position3D)
                {
                    Position3D p3d = item as Position3D;
                    bytes.Add(TraCIConstants.POSITION_3D);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPosition3D(p3d));
                }
                else if (item is RoadMapPosition)
                {
                    RoadMapPosition rmp = item as RoadMapPosition;
                    bytes.Add(TraCIConstants.POSITION_ROADMAP);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromRoadMapPosition(rmp));
                }
                else if (item is LonLatPosition)
                {
                    LonLatPosition llp = item as LonLatPosition;
                    bytes.Add(TraCIConstants.POSITION_LON_LAT);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromLonLatPosition(llp));
                }
                else if (item is LonLatAltPosition)
                {
                    LonLatAltPosition llap = item as LonLatAltPosition;
                    bytes.Add(TraCIConstants.POSITION_LON_LAT_ALT);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromLonLatAltPosition(llap));
                }
                else if (item is BoundaryBox)
                {
                    BoundaryBox bb = item as BoundaryBox;
                    bytes.Add(TraCIConstants.TYPE_BOUNDINGBOX);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromBoundaryBox(bb));
                }
                else if (item is Polygon)
                {
                    Polygon p = item as Polygon;
                    bytes.Add(TraCIConstants.TYPE_POLYGON);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPolygon(p));
                }
                else if (item is TrafficLightPhaseList)
                {
                    TrafficLightPhaseList tlpl = item as TrafficLightPhaseList;
                    bytes.Add(TraCIConstants.TYPE_TLPHASELIST);
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromTrafficLightPhaseList(tlpl));
                }
                else if (item is Color)
                {
#warning missing code
                    throw new NotImplementedException();
                }
                else
                {
                    throw new InvalidCastException($"Type {item.GetType().Name} is not implemented");
                }
            }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType)
		{
			var bytes = new List<byte> { messageType };
			bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
			var command = new TraCICommand
			{
				Identifier = commandType,
				Contents = bytes.ToArray()
			};
			return command;
		}

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, BoundaryBox boundaryBox)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_BOUNDINGBOX);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftX));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftY));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightX));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightY));

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Polygon polygon)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_POLYGON);
            bytes.Add((byte)polygon.Points.Count);
            foreach (var point in polygon.Points)
            {
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.X));
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.Y));
            }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Position2D position2D)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.POSITION_2D);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(position2D.X));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(position2D.Y));

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Color color)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COLOR);
            bytes.Add(color.R);
            bytes.Add(color.G);
            bytes.Add(color.B);
            bytes.Add(color.A);

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, List<string> values)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            
            if (values != null && values.Count > 0)
            {
                bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(values.Count));
                foreach (var parameter in values)
                {
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(parameter));
                }
            }
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, string value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, double value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_DOUBLE);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, int value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_INTEGER);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, byte value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_BYTE);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromByte(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }


    }
}

