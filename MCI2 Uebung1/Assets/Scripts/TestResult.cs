using Cursors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestResult {
    public CursorMovementType cursor;

    public float averageTime {
        get {
            return testSize > 0
                ? times.Average()
                : 0f;
        }
    }
    public float errorRate {
        get {
            return testSize > 0
                ? hits.Average(hit => hit ? 0f : 1f)
                : 0f;
        }
    }
    public string name { get; private set; }
    public DateTime date {
        get {
            return DateTime.Now;
        }
    }

    private List<float> times = new List<float>();
    private List<bool> hits = new List<bool>();

    public int testSize {
        get {
            return times.Count;
        }
    }

    public TestResult(string name) {
        this.name = name;
    }
    public void AddRecord(float time, bool hit) {
        times.Add(time);
        hits.Add(hit);
    }
}
