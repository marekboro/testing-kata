using Xunit;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    class ClientFake : ITelemetryClient
    {
        public bool sendCalled = false;
        public void Connect(string telemetryServerConnectionString)
        {
            OnlineStatus = true;
        }

        public void Disconnect()
        {
            
        }

        public void Send(string message)
        {
            sendCalled = true;
        }

        public string Receive()
        {
            return "iu";
        }

        public bool OnlineStatus { get; set; }
    }

    public class TelemetryDiagnosticControlsTest
    {
        [Fact]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
            //Arrange

            var clientFake = new ClientFake();
            var telemetryDiagnosticControls = new TelemetryDiagnosticControls(clientFake);

            //Act
            telemetryDiagnosticControls.CheckTransmission();
            
            //Assert
            
            Assert.NotEmpty(telemetryDiagnosticControls.DiagnosticInfo);
            Assert.True(clientFake.sendCalled);

        }
    }
}
