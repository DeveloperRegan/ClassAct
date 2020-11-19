using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAct.Website.BL.GoogleAPI;

namespace ClassAct.Website.BL.Test
{
    [TestClass]
    public class utAPIConnector
    {
        [TestMethod]
        public void GetPhotoReferenceTest()
        {
            CAPIConnector api = new CAPIConnector();
            api.GetPhotoReference("ChIJ_7tDnU23A4gR1PZ3Nx993M4");



        }

        [TestMethod]
        public void GetPlaceIdTest()
        {
            CAPIConnector api = new CAPIConnector();
            //api.GetPlaceId();


        }

        [TestMethod]
        public void ConstructPhotoURLTest()
        {
            CAPIConnector api = new CAPIConnector();
            api.GetPhoto("CmRaAAAAr2Qgfh2NRs7FZLfDI4Wd0Yx6Ah0iodC0zpirMNahsLtDyv_lbsLMLAnAW7ZP8hkyKwt0Lr9MW-iqnRiiIRRAnZGGxFA3P2xzhXAa5wbMFewS1bSp2QYkfowKaNOE1WFuEhAOuFzomHtGBCwhErT8VDM-GhSiyj-XfGtUOzCJ7qdjnXnOrNcuJw", 200);


        }
    }
}
