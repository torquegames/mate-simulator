using System;

public interface IPooleable
{
    Guid Guid { get; set; } //The guid is for multiple pools situations
    bool IsPooled { get; set; }
}