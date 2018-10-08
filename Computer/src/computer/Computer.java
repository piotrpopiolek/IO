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
public class Computer {

    private String HDD;
    private String RAM;

    private boolean isHyperVEnabled;
    private boolean isHDMIEnabled;
    public String getHDD() {
        return HDD;
    }
    public String getRAM() {
        return RAM;
    }
    public boolean isHyperVEnabled() {
        return isHyperVEnabled;
    }
    public boolean isHDMIEnabled() {
        return isHDMIEnabled;
    }
    private Computer(ComputerBuilder builder) {
        this.HDD=builder.HDD;
        this.RAM=builder.RAM;
        this.isHyperVEnabled=builder.isHyperVEnabled;
        this.isHDMIEnabled=builder.isHDMIEnabled;
    }



    //Builder Class
    public static class ComputerBuilder{

        private String HDD;
        private String RAM;

        private boolean isHyperVEnabled;
        private boolean isHDMIEnabled;
        public ComputerBuilder(String hdd, String ram){
            this.HDD=hdd;
            this.RAM=ram;
        }
        public ComputerBuilder setHyperVEnabled(boolean isHyperVEnabled) {
            this.isHyperVEnabled = isHyperVEnabled;
            return this;
        }
        public ComputerBuilder setHDMIEnabled(boolean isHDMIEnabled) {
            this.isHDMIEnabled = isHDMIEnabled;
            return this;
        }
        public Computer build(){
            return new Computer(this);
        }
    }
}
