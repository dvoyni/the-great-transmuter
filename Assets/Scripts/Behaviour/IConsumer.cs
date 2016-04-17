using UnityEngine;

public interface IConsumer {
    void Consume(Element element);
    Transform transform { get; }
}
