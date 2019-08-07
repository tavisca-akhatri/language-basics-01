public class MultiplicationAnswer {
    private int val1;
    private int val2;
    public MultiplicationAnswer(int val1,int val2){
        this.val1=val1;
        this.val2=val2;
    }

    public int getMultiplicationAnswer(String operand3){
        int val3 = val1*val2;
        String originalOperand = Integer.toString(val3);
        if(originalOperand.length() != operand3.length()){
            return -1;
        }
        int index = operand3.indexOf('?');
        Character result = originalOperand.charAt(index);
        if(result - '0' == 0 && index == 0)
            return -1;
        else
            return result-'0';
    }
}
