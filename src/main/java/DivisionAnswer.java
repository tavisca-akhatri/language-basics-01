public class DivisionAnswer {
    private int val3;
    private int val2;
    public DivisionAnswer(int val3,int val2){
        this.val3 = val3;
        this.val2 = val2;
    }
    public int getMultiplicationAnswer(String operand1){
        int val1 = val3/val2;
        String originalOperand = Integer.toString(val1);
        if(originalOperand.length() != operand1.length()){
            return -1;
        }
        int index = operand1.indexOf('?');
        Character result = originalOperand.charAt(index);
        if(result - '0' == 0 && index == 0)
            return -1;
        else
            return result-'0';
    }
}
