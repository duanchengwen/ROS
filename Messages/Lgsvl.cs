/**
 * Copyright (c) 2019-2020 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections.Generic;
using Simulator.Bridge.Ros.Ros;

namespace Simulator.Bridge.Ros.Lgsvl
{
    public enum Gear: byte
    {
        GEAR_NEUTRAL = 0,
        GEAR_DRIVE = 1,
        GEAR_REVERSE = 2,
        GEAR_PARKING = 3,
        GEAR_LOW = 4,
    }

    public enum BlinkerState: byte
    {
        BLINKERS_OFF = 0,
        BLINKERS_LEFT = 1,
        BLINKERS_RIGHT = 2,
        BLINKERS_HAZARD = 3,
    }

    public enum HeadlightState: byte
    {
        HEADLIGHTS_OFF = 0,
        HEADLIGHTS_LOW = 1,
        HEADLIGHTS_HIGH = 2,
    }

    public enum WiperState: byte
    {
        WIPERS_OFF = 0,
        WIPERS_LOW = 1,
        WIPERS_MED = 2,
        WIPERS_HIGH = 3,
    }

    public enum VehicleMode: byte
    {
        VEHICLE_MODE_COMPLETE_MANUAL = 0,
        VEHICLE_MODE_COMPLETE_AUTO_DRIVE = 1,
        VEHICLE_MODE_AUTO_STEER_ONLY = 2,
        VEHICLE_MODE_AUTO_SPEED_ONLY = 3,
        VEHICLE_MODE_EMERGENCY_MODE = 4,
    }

    public enum LaneLineType: byte
    {
        WhiteDashed = 0,
        WhiteSolid = 1,
        YellowDashed = 2,
        YellowSolid = 3,
    }

    public enum LaneLinePositionType: sbyte
    {
        BollardLeft = -5,
        FourthLeft = -4,
        ThirdLeft = -3,
        AdjacentLeft = -2,
        EgoLeft = -1,
        EgoRight = 1,
        AdjacentRight = 2,
        ThirdRight = 3,
        FourthRight = 4,
        BollardRight = 5,
        Other = 6,
        Unknown = 7,
    }

    public enum ObjectState
    {
        STATE_MOVING = 0,
        STATE_STATIONARY = 1,
    }

    [MessageType("lgsvl_srvs/Int")]
    public class Int
    {
        public int data;
    }

    [MessageType("lgsvl_srvs/String")]
    public class String
    {
        public string str;
    }

    [MessageType("lgsvl_msgs/BoundingBox2D")]
    public class BoundingBox2D
    {
        public float x;
        public float y;

        public float width;
        public float height;
    }

    [MessageType("lgsvl_msgs/BoundingBox3D")]
    public class BoundingBox3D
    {
        public Ros.Pose position;
        public Ros.Vector3 size;
    }

    [MessageType("lgsvl_msgs/Detection2D")]
    public class Detection2D
    {
        public Ros.Header header;

        public uint id;
        public string label;
        public double score;

        public BoundingBox2D bbox;
        public Ros.Twist velocity;
    }

    [MessageType("lgsvl_msgs/Detection2DArray")]
    public class Detection2DArray
    {
        public Ros.Header header;
        public List<Detection2D> detections;
    }

    [MessageType("lgsvl_msgs/Detection3D")]
    public class Detection3D
    {
        public Ros.Header header;

        public uint id;
        public string label;
        public double score;

        public BoundingBox3D bbox;
        public Ros.Twist velocity;
    }

    [MessageType("lgsvl_msgs/Detection3DArray")]
    public class Detection3DArray
    {
        public Ros.Header header;
        public List<Detection3D> detections;
    }

    [MessageType("lgsvl_msgs/LaneLineCubicCurve")]
    public class LaneLineCubicCurve
    {
        public float longitude_min;
        public float longitude_max;
        public float a;
        public float b;
        public float c;
        public float d;
    }

    [MessageType("lgsvl_msgs/LaneLine")]
    public class LaneLine
    {
        public Ros.Header header;
        public LaneLineType type;
        public LaneLinePositionType pos_type;
        public LaneLineCubicCurve curve_camera_coord;
    }
    
    [MessageType("lgsvl_msgs/LaneLineArray")]
    public class LaneLineArray
    {
        public Ros.Header header;
        public List<LaneLine> camera_laneline;
    }

    [MessageType("lgsvl_msgs/Signal")]
    public class Signal
    {
        public Ros.Header header;
        public uint id;
        public string label;
        public double score;
        public BoundingBox3D bbox;
    }

    [MessageType("lgsvl_msgs/SignalArray")]
    public class SignalArray
    {
        public Ros.Header header;
        public List<Signal> signals;
    }

    [MessageType("lgsvl_msgs/CanBusData")]
    public class CanBusDataRos
    {
        public Ros.Header header;

        public float speed_mps;
        public float throttle_pct;  // 0 to 1
        public float brake_pct;     // 0 to 1
        public float steer_pct;     // -1 to 1
        public bool parking_brake_active;
        public bool high_beams_active;
        public bool low_beams_active;
        public bool hazard_lights_active;
        public bool fog_lights_active;
        public bool left_turn_signal_active;
        public bool right_turn_signal_active;
        public bool wipers_active;
        public bool reverse_gear_active;
        public Gear selected_gear;
        public bool engine_active;
        public float engine_rpm;
        public double gps_latitude;
        public double gps_longitude;
        public double gps_altitude;
        public Ros.Quaternion orientation;
        public Ros.Vector3 linear_velocities;
    }

    [MessageType("lgsvl_msgs/VehicleControlData")]
    public class VehicleControlDataRos
    {
        public Ros.Header header;

        public float acceleration_pct;          // 0 to 1
        public float braking_pct;               // 0 to 1
        public float target_wheel_angle;        // radians
        public float target_wheel_angular_rate; // radians / second
        public Gear target_gear;
    }

    [MessageType("lgsvl_msgs/VehicleStateData")]
    public class VehicleStateDataRos
    {
        public Ros.Header header;

        public BlinkerState blinker_state;
        public HeadlightState headlight_state;
        public WiperState wiper_state;
        public Gear current_gear;
        public VehicleMode vehicle_mode;
        public bool hand_brake_active;
        public bool horn_active;
        public bool autonomous_mode_active;
    }

    [MessageType("lgsvl_msgs/VehicleOdometry")]
    public class VehicleOdometry
    {
        public Header header;
        public float velocity;
        public float front_wheel_angle;
        public float rear_wheel_angle;
    }

    [MessageType("lgsvl_msgs/DetectedRadarObject")]
    public class DetectedRadarObject
    {
        public int id;

        public Ros.Vector3 sensor_aim;
        public Ros.Vector3 sensor_right;
        public Ros.Point sensor_position;
        public Ros.Vector3 sensor_velocity;
        public double sensor_angle;

        public Ros.Point object_position;
        public Ros.Vector3 object_velocity;
        public Ros.Point object_relative_position;
        public Ros.Vector3 object_relative_velocity;
        public Ros.Vector3 object_collider_size;
        public byte object_state;
        public bool new_detection;
    }

    [MessageType("lgsvl_msgs/DetectedRadarObjectArray")]
    public class DetectedRadarObjectArray
    {
        public Ros.Header header;

        public List<DetectedRadarObject> objects;
    }

    [MessageType("lgsvl_msgs/Ultrasonic")]
    public class Ultrasonic
    {
        public Ros.Header header;

        public float minimum_distance;
    }
}
