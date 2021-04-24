namespace JimmyHaglund.ObjectBehaviour {
    interface ITurnable {
        void SetForward(float forwardX, float forwardY, float forwardZ);
        void SetForwardTarget(float forwardX, float forwardY, float forwardZ);
        float TurnRadiansPerSecond { get; set; }
    }
}
