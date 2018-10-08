/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package computer;

/**
 *
 * @author piotr_000
 */
public class ComputerBulider {
     public static void main(String[] args) {

        Computer comp = new Computer.ComputerBuilder(
                "320 GB", "5 GB").setHDMIEnabled(true)
                .setHyperVEnabled(true).build();
    }
}
