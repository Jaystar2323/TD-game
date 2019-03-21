using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaveList{

    public float numCluster;
    public float numCluster2;
    public float numFast;
    public float numBig;
    public float numNormal;
    public float numFast2;
    public float numSplitter;
    public float timeBetweenSpawns;
    public float waveCount;
    

    public WaveList()
    {
        numCluster *= 2;
        numCluster2 *= 2;
        numFast *= 2;
        numBig *= 2;
        numNormal *= 2;
        numFast2 *= 2;
        numSplitter *= 2;
        //float current = numCluster;
        //if (current < numCluster2)
        //{
        //    current = numCluster2;
        //}
        //if (current < numFast)
        //{
        //    current = numFast;
        //}
        //if (current < numFast2)
        //{
        //    current = numFast2;
        //}
        //if (current < numNormal)
        //{
        //    current = numNormal;
        //}
        //if (current < numBig)
        //{
        //    current = numBig;
        //}
        //waveCount = current;
    }

    public float highestCount()
    {
        return waveCount;
    }

    //public WaveList(int numCluster, int numCluster2, int numFast, int numFast2, int numBig, int numNormal)
    //{
    //    this.numCluster = numCluster;
    //    this.numCluster2 = numCluster2;
    //    this.numFast = numFast;
    //    this.numFast2 = numFast2;
    //    this.numBig = numBig;
    //    this.numNormal = numNormal;
    //}

    //public int getNumCluster()
    //{
    //    return numCluster;
    //}
    //public int getNumCluster2()
    //{
    //    return numCluster2;
    //}
    //public int getNumFast()
    //{
    //    return numFast;
    //}
    //public int getNumCFast2()
    //{
    //    return numFast2;
    //}
    //public int getBig()
    //{
    //    return numBig;
    //}
    //public int getNumNormal()
    //{
    //    return numNormal;
    //}

}
