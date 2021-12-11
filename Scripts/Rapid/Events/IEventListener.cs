namespace JHTools.Rapid {
    public interface IEventListener {
        void OnEventRaised();
    }
    public class IFEventListener : InterfaceField<IEventListener> { }

    public interface IEventListener<T> {
        void OnEventRaised(T arg);
    }
    public class IFEventListener<T> : InterfaceField<IEventListener<T>> { }

    public interface IEventListener<T1, T2> {
        void OnEventRaised(T1 arg1, T2 arg2);
    }
    public class IFEventListener<T1, T2> : InterfaceField<IEventListener<T1, T2>> { }

    public interface IEventListener<T1, T2, T3> {
        void OnEventRaised(T1 arg1, T2 arg2, T3 arg3);
    }
    public class IFEventListener<T1, T2, T3> : InterfaceField<IEventListener<T1, T2, T3>> { }

    public interface IEventListener<T1, T2, T3, T4> {
        void OnEventRaised(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }
    public class IFEventListener<T1, T2, T3, T4> : InterfaceField<IEventListener<T1, T2, T3, T4>> { }

    public interface IEventListener<T1, T2, T3, T4, T5> {
        void OnEventRaised(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
    public class IFEventListener<T1, T2, T3, T4, T5> : InterfaceField<IEventListener<T1, T2, T3, T4, T5>> { }
}
