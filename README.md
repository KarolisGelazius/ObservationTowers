# ObservationTowers
Algorithm to find the minimum moves required for optimal observation tower placement on an N×N grid.

## Program User Manual

### 1. Prepare the Input Data
Ensure the input data file `U3.txt` is located in the working directory (`App_Data/U3.txt`). The file must follow this structure:
* **Line 1:** The grid dimension $N$ ($N \times N$ matrix).
* **Line 2:** Space-separated $X$ coordinates of the towers.
* **Line 3:** Space-separated $Y$ coordinates of the towers.

**Example `U3.txt`:**
```text
4
1 1 3 3
1 3 3 4
