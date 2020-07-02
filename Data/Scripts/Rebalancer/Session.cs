using Sandbox.Definitions;
using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Components;
using VRage.Utils;

namespace Keyspace.Rebalancer
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class Rebalancer_Session : MySessionComponentBase
    {
        public static Rebalancer_Session Instance;

        public override void LoadData()
        {
            Instance = this;
        }

        public override void BeforeStart()
        {
            // FIXME: try MyDefinitionManager.Static.GetAllDefinitions<MyCubeBlockDefinition>()
            var definitions = MyDefinitionManager.Static.GetAllDefinitions();
            var cubeBlockDefinitions = definitions.ToList().Where(d => d is MyCubeBlockDefinition);

            //MyLog.Default.WriteLineAndConsole("DEBUG DEFINITIONS:");
            //foreach (var cbd in cubeBlockDefinitions)
            //{
            //    MyLog.Default.WriteLineAndConsole(cbd.DisplayNameText);
            //}

            MyLog.Default.WriteLineAndConsole("DEBUG SCANNING DEFINITIONS");
            foreach (var cbd in cubeBlockDefinitions)
            {
                if (cbd.Id.TypeId.ToString() == "MyObjectBuilder_OxygenGenerator")
                {
                    MyLog.Default.WriteLineAndConsole("DEBUG FOUND");
                    var og = cbd as MyOxygenGeneratorDefinition;
                    og.OperationalPowerConsumption *= 2.0f;
                }
            }
        }

        protected override void UnloadData()
        {
            Instance = null;
        }

        //public override void UpdateAfterSimulation()
        //{
        //}
    }
}
