using Hakoniwa.PluggableAsset.Assets.Robot.Parts;
using Hakoniwa.PluggableAsset.Communication.Connector;
using Hakoniwa.PluggableAsset.Communication.Pdu;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hakoniwa.PluggableAsset.Assets.Robot.Zumo
{
    public class ZumoMotorControllerTestDriver : MonoBehaviour, IRobotPartsController
    {
        private GameObject root;
        private string root_name;
        private PduIoConnector pdu_io;
        private IPduReader pdu_reader;
        public string roboname = "ZumoRoboModel";

        public void Initialize(System.Object obj)
        {
            GameObject tmp = null;
            try
            {
                tmp = obj as GameObject;
            }
            catch (InvalidCastException e)
            {
                Debug.LogError("Initialize error: " + e.Message);
                return;
            }

            if (this.root == null)
            {
                this.root = tmp;
                this.root_name = string.Copy(this.root.transform.name);
                this.pdu_io = PduIoConnector.Get(roboname);
                if (this.pdu_io == null)
                {
                    throw new ArgumentException("can not found pdu_io:" + roboname);
                }
                var pdu_io_name = roboname + "_" + "actuatorPdu";
                this.pdu_reader = this.pdu_io.GetReader(pdu_io_name);
                if (this.pdu_reader == null)
                {
                    throw new ArgumentException("can not found pdu_reader:" + pdu_io_name);
                }
            }
        }
        public void DoControl()
        {
            this.pdu_reader.GetWriteOps().Refs("motors")[(int)ZumoMotorType.MotorType_Left].SetData("power", this.left_power);
            this.pdu_reader.GetWriteOps().Refs("motors")[(int)ZumoMotorType.MotorType_Right].SetData("power", this.right_power);
        }
        private int left_power = 0;
        private int right_power = 0;
        private int delta = 1;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.left_power  += this.delta;
                this.right_power += this.delta;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.left_power -= this.delta;
                this.right_power -= this.delta;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.left_power += this.delta;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.right_power += this.delta;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key is pressed");
                this.left_power = 0;
                this.right_power = 0;
            }
        }
        public RosTopicMessageConfig[] getRosConfig()
        {
            return new RosTopicMessageConfig[0];
        }
    }

}
