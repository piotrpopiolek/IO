/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package computer;

import org.junit.Assert;
import org.junit.Test;

/**
 *
 * @author piotr_000
 */
public class ComputerTest {
   
    @Test
    public void testComputerBuilderBuildClassOn(){
        Computer comp = new Computer.ComputerBuilder(
                "512 GB", "4 GB").setHDMIEnabled(false)
                .setHyperVEnabled(false).build();

        String expectedHDDAmount = "512 GB";
        String expectedRAMAmount = "4 GB";

        Assert.assertEquals("Wartosc HHD = 512GB",expectedHDDAmount,comp.getHDD());
        Assert.assertEquals("Wartosc RAM =  4GB",expectedRAMAmount,comp.getRAM());
    }
    
    
   @Test
    public void testComputerBuilderBuildClassOff(){
        Computer comp = new Computer.ComputerBuilder(
                "320 GB", "5 GB").setHDMIEnabled(true)
                .setHyperVEnabled(true).build();

        String expectedHDDAmount = "320 GB";
        String expectedRAMAmount = "5 GB";

        Assert.assertEquals("Wartosc HHD = 320GB",expectedHDDAmount,comp.getHDD());
        Assert.assertEquals("Wartosc RAM =  5GB",expectedRAMAmount,comp.getRAM());
    }

    @Test
    public void chechComputerWithHDMIEnabled(){
        Computer comp = new Computer.ComputerBuilder(
                "320 GB", "5 GB").setHDMIEnabled(true)
                .setHyperVEnabled(false).build();
        
        Assert.assertTrue("HDMI wlaczone", comp.isHDMIEnabled());
    }

    @Test
    public void chechComputerWithHyperVEnabled(){
        Computer comp = new Computer.ComputerBuilder(
                "320 GB", "5 GB").setHDMIEnabled(false)
                .setHyperVEnabled(true).build();

        Assert.assertTrue("HyperV wlaczona", comp.isHyperVEnabled());
    }
    
    @Test
    public void chechComputerWithVEnabledOptions(){
        Computer comp = new Computer.ComputerBuilder(
                "320 GB", "5 GB").setHDMIEnabled(false)
                .setHyperVEnabled(false).build();

        Assert.assertFalse("HDMI wylaczona", comp.isHyperVEnabled());
        Assert.assertFalse("HyperV wylaczona", comp.isHyperVEnabled());
    }
}
