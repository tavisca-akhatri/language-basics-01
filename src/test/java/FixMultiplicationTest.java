import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;
public class FixMultiplicationTest {

    @Test
    public void checkFixMultiplication(){
        assertEquals(9,new FixMultiplication().findDigit("42*47=1?74"));
        assertEquals(2,new FixMultiplication().findDigit("4?*47=1974"));
        assertEquals(4,new FixMultiplication().findDigit("42*?7=1974"));
        assertEquals(-1,new FixMultiplication().findDigit("42*?47=1974"));
        assertEquals(-1,new FixMultiplication().findDigit("2*12?=247"));
    }
}
