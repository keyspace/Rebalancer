using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
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
            var definitions = MyDefinitionManager.Static.GetAllDefinitions();
            var cubeBlockDefinitions = definitions.ToList().Where(d => d is MyCubeBlockDefinition);

            MyLog.Default.WriteLineAndConsole("XXX DEFINITIONS:");
            foreach (var cbd in cubeBlockDefinitions)
            {
                MyLog.Default.WriteLineAndConsole(cbd.DisplayNameText);
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
