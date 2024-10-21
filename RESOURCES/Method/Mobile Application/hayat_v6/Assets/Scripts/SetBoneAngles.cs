using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetBoneAngles : MonoBehaviour
{
    /*private float tighLength = 0.0f;
    private float calfLength = 0.0f;
    private float footPosX = 0.0f;
    private float footPosY = 0.0f;
    private float tighPosX = 0.0f;
    private float tighPosY = 0.0f;

    public SetBoneAngles(float tighLength, float calfLength, float footPosX, float footPosY, float tighPosX, float tighPosY) {
        this.tighLength = tighLength;
        this.calfLength = calfLength;
        this.footPosX = footPosX;
        this.footPosY = footPosY;
        this.tighPosX = tighPosX;
        this.tighPosY = tighPosY;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(getAngles(4, 3, 5, 5, 2, 1)[1]);
    }

    public double[] getAngles(double tighLength, double calfLength, double footPosX, double footPosY, double footPosZ, double tighPosX, double tighPosY, double tighPosZ) {
        double xDistance = tighPosX - footPosX;
        double yDistance = tighPosY - footPosY;
        if(getUnknownLength(xDistance, yDistance) >= calfLength + tighLength) {
            double divisionCount = (calfLength + tighLength) / getUnknownLength(xDistance, yDistance);
            xDistance *= divisionCount;
            yDistance *= divisionCount;
            yDistance -= 0.07d;
            xDistance -= 0.07d;
            print("dfgfh");
        }
        double[] angles = {xDistance < 0 ? getCalfLength(getUnknownLength(xDistance, yDistance), Math.Abs(xDistance), Math.Abs(yDistance)) - getCalfLength(tighLength, calfLength, getUnknownLength(xDistance, yDistance)) : -(getCalfLength(getUnknownLength(xDistance, yDistance), Math.Abs(xDistance), Math.Abs(yDistance)) + getCalfLength(tighLength, calfLength, getUnknownLength(xDistance, yDistance))), 180.0d - getCalfLength(tighLength, getUnknownLength(xDistance, yDistance), calfLength), 0.0d, 0.0d};
        double teta = getCalfLength(calfLength, tighLength, getUnknownLength(xDistance, yDistance));
        double alpha = getCalfLength(xDistance, yDistance, getUnknownLength(xDistance, yDistance));
        double t = 180.0d - (alpha + teta);
        double l = calfLength * Math.Sin((t * Math.PI) / 180);
        double beta = 90 - alpha;
        double r = getCalfLength(tighLength, calfLength, getUnknownLength(xDistance, yDistance));
        double p = 90.0d - (r + beta);
        double q = tighLength * Math.Sin((p * Math.PI) / 180);
        double yDistanceYVision = Math.Abs(tighPosY - footPosY);
        double zDistanceYVision = Math.Abs(tighPosZ - footPosZ);
        if(getUnknownLength(yDistanceYVision, zDistanceYVision) >= l + q) {
            double divisionCount = (l + q) / getUnknownLength(yDistanceYVision, zDistanceYVision);
            yDistanceYVision *= divisionCount;
            zDistanceYVision *= divisionCount;
            yDistanceYVision -= 0.05d;
            zDistanceYVision -= 0.05d;
        }
        //print((Math.Sin((53 * Math.PI) / 180)));
        q *= getUnknownLength(zDistanceYVision, yDistanceYVision) / (q + l);
        l *= getUnknownLength(zDistanceYVision, yDistanceYVision) / (q + l);
        q += 0.05d;
        l += 0.05d;
        //print(getUnknownLength(zDistanceYVision, yDistanceYVision) + " " + q + " " + l + " " + p + " " + t);
        angles[2] = - getCalfLength(getUnknownLength(zDistanceYVision, yDistanceYVision), zDistanceYVision, yDistanceYVision) + getCalfLength(getUnknownLength(zDistanceYVision, yDistanceYVision), l, q);
        angles[3] = - 180.0d + getCalfLength(l, getUnknownLength(zDistanceYVision, yDistanceYVision), q);
        if(tighPosZ - footPosZ > 0) {
            angles[2] *= -1;
            angles[3] *= -1;
        }
        //print(angles[3]);
        return angles;
    }

    private double getUnknownLength(double xDistance, double yDistance) {
        return Math.Sqrt((Math.Abs(xDistance) * Math.Abs(xDistance)) + (Math.Abs(yDistance) * Math.Abs(yDistance)));
    }

    private double getCalfLength(double tigh, double calf, double other) {
        return (180 / Math.PI) * Math.Acos(((double)((double)tigh * (double)tigh) + (double)((double)other * (double)other) - (double)((double)calf * (double)calf)) / (double)(2.0d * (double)tigh * (double)other));
    }
}
