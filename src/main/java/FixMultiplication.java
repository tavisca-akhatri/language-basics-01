public class FixMultiplication {
    public int findDigit(String equation) {
        int starIndex = equation.indexOf('*');
        int equalIndex = equation.indexOf('=');
        String operand1 = equation.substring(0, starIndex);
        String operand2 = equation.substring(starIndex + 1, equalIndex);
        String operand3 = equation.substring(equalIndex + 1);
        if (operand1.indexOf('?') != -1 || operand2.indexOf('?') != -1) {
            if (operand2.indexOf('?') != -1) {
                String temp = operand1;
                operand1 = operand2;
                operand2 = temp;
            }
            int val3 = Integer.parseInt(operand3);
            int val2 = Integer.parseInt(operand2);
            return new DivisionAnswer(val3, val2).getMultiplicationAnswer(operand1);
        }
        else{
            int val1 = Integer.parseInt(operand1);
            int val2 = Integer.parseInt(operand2);
            return new MultiplicationAnswer(val1, val2).getMultiplicationAnswer(operand3);
        }
    }
}
