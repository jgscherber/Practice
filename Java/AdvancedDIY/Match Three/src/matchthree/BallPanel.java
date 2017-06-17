package matchthree;


import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;

public class BallPanel extends JPanel{
    private static final int ROWS = 10;
    private static final int COLS = 6;
    private static final int WIDTH = COLS * Cell.SIZE;
    private static final int HEIGHT = ROWS * Cell.SIZE;
    private MatchThree game;
    private Cell[][] cells = new Cell[ROWS][COLS];

    // swapping
    private static final int
            DIRECTION_NONE = 0,
            DIRECTION_LEFT = 1,
            DIRECTION_RIGHT = 2,
            DIRECTION_UP = 3,
            DIRECTION_DOWN = 4;

    private static final Cursor
            HORIZONTAL_ARROWS = new Cursor(Cursor.W_RESIZE_CURSOR),
            VERTICAL_ARROWS = new Cursor(Cursor.N_RESIZE_CURSOR),
            DEFAULT_CURSOR = new Cursor(Cursor.DEFAULT_CURSOR);


    public BallPanel(MatchThree game) {
        this.game = game;
        setLayout(new GridLayout(ROWS, COLS));
        setInitialBalls();

        addMouseListener(new MouseAdapter() {
            @Override
            public void mouseReleased(MouseEvent e) {
                int x = e.getX();
                int y = e.getY();
                clicked(x, y);
            }
        });

        addMouseMotionListener(new MouseMotionAdapter() {
            @Override
            public void mouseMoved(MouseEvent e) {
                int x = e.getX();
                int y = e.getY();
                mouseMovedTo(x,y);
            }
        });

    }

    // ball placement
    private void setInitialBalls() {
        for(int row = 0; row < ROWS; row++) {
            for(int col = 0; col < COLS; col++) {
                cells[row][col] = new Cell();
                // can only do above and to left while instantiating, others don't
                // exist yet
                while (twoMatchAbove(row, col) || twoMatchToLeft(row, col)) {
                    cells[row][col] = new Cell();
                }
            }
        }
        repaint();
    }

    private boolean twoMatchAbove(int row, int col) {
        boolean match = false;
        if (row > 1 && row < ROWS &&
                col >= 0 && col < COLS) {
            int color1 = cells[row][col].getColor();
            int color2 = cells[row-1][col].getColor();
            int color3 = cells[row-2][col].getColor();
            if (color1 == color2 && color1 == color3) {
                match = true;
            }
        }
        return match;
    }

    private boolean twoMatchToLeft(int row, int col) {
        boolean match = false;
        if (row >= 0 && row < ROWS &&
                col > 1 && col < COLS) {
            int color1 = cells[row][col].getColor();
            int color2 = cells[row][col-1].getColor();
            int color3 = cells[row][col-2].getColor();
            if (color1 == color2 && color1 == color3) {
                match = true;
            }
        }
        return match;
    }

    // scoring

    private int markChainsAndGetPointsInRow(int row) {
        int points = 0;
        // get first ball
        int color = cells[row][0].getColor();
        int count = 1;
        // loop through each column
        for(int col = 1; col < COLS; col++) {
            // marks chains of 3 or more
            int nextColor = cells[row][col].getColor();
            if (nextColor == color) count++;
            else{
                points += calculatePoints(count);
                color = nextColor;
                count = 1;
            }
            if (count == 3) {
                cells[row][col].setInChain(true);
                cells[row][col-1].setInChain(true);
                cells[row][col-2].setInChain(true);
            } else if (count > 3) {
                cells[row][col].setInChain(true);
            }

        }
        points += calculatePoints(count);
        return points;
    }

    private int markChainsAndGetPointsInCol(int col) {
        int points = 0;
        // get first ball
        int color = cells[0][col].getColor();
        int count = 1;
        // loop through each column
        for(int row = 1; row < ROWS; row++) {
            // marks chains of 3 or more
            int nextColor = cells[row][col].getColor();
            if (nextColor == color) count++;
            else{
                points += calculatePoints(count);
                color = nextColor;
                count = 1;
            }
            if (count == 3) {
                cells[row][col].setInChain(true);
                cells[row-1][col].setInChain(true);
                cells[row-2][col].setInChain(true);
            } else if (count > 3) {
                cells[row][col].setInChain(true);
            }

        }
        points = calculatePoints(count);
        return points;
    }

    private int calculatePoints(int count) {
        int points = 0;
        if( count == 3) {
            points = 10;
        } else if (count == 4) {
            points = 15;
        } else if (count > 4) {
            points = 20;
        }
        return points;
    }

    private void removeMarkedChains(){
        // pausing before clear
        pause(1000);
        // remove marked chains
        for(int row = 0; row < ROWS; row++) {
            for(int col = 0; col < COLS; col++) {
                Cell temp = cells[row][col];
                if (temp.isInChain()) {
                    temp.setEmpty();
                }
            }
        }
        repaint();
        pause(500);
        // loop through rows and columns starting at the bottom
        for(int row = ROWS-1; row > -1; row--) {
            boolean foundEmptyInCol = false;
            for(int col = 0; col < COLS; col++) {
                // if empty, copy the first non-empty cell above it
                if (cells[row][col].isEmpty()) {
                    foundEmptyInCol = true;
                    boolean foundBall = false;
                    for(int r = row - 1; row >= 0 && !foundBall; r--) {
                        if (!cells[r][col].isEmpty()) {
                            cells[row][col].copy(cells[r][col]);
                            cells[r][col].setEmpty();
                            foundBall = true;
                        }
                    }
                    // if none above, refill with new
                    if (!foundBall) {
                        cells[row][col] = new Cell();
                    }
                }


            }
            // repaint and pause after each row (for effect)
            repaint();
            if (foundEmptyInCol) {
                pause(500);
            }
        }
    } // end removeMarkedChains()


    // swapping code

    private void mouseMovedTo(int x, int y) {
        int direction = getSwapDirection(x, y);
        switch (direction) {
            case DIRECTION_LEFT:
            case DIRECTION_RIGHT:
                setCursor(HORIZONTAL_ARROWS);
                break;
            case DIRECTION_UP:
            case DIRECTION_DOWN:
                setCursor(VERTICAL_ARROWS);
                break;
            default:
                setCursor(DEFAULT_CURSOR);
        }
    }

    private void clicked(int x, int y) {
        int row = y / Cell.SIZE;
        int col = x / Cell.SIZE;
        int direction = getSwapDirection(x, y);
        switch (direction) {
            case DIRECTION_NONE:
                break;
            case DIRECTION_LEFT:
                swap(row,col,row, col-1);
                break;
            case DIRECTION_RIGHT:
                swap(row, col, row, col + 1);
                break;
            case DIRECTION_UP:
                swap(row,col,row-1,col);
                break;
            case DIRECTION_DOWN:
                swap(row,col,row+1, col);
                break;
        }
    }

    private int getSwapDirection(int x, int y) {
        int direction = DIRECTION_NONE;
        // DETERMINE WHICH CELL
        int cellSize = Cell.SIZE;
        int col = x / cellSize;
        int row = y / cellSize;

        //  EDGE DISTANCE
        int left = x % cellSize;
        int right = cellSize - left;
        int top = y % cellSize;
        int bottom = cellSize - top;

        // IF NOT BAD EDGE
        if (col > 0 &&
                left < right &&
                left < top &&
                left < bottom) {
            direction = DIRECTION_LEFT;
        } else if (col < COLS - 1 &&
                right < left &&
                right < top &&
                right < bottom) {
            direction = DIRECTION_RIGHT;
        } else if (row > 0 &&
                top < left &&
                top < right &&
                top < bottom) {
            direction = DIRECTION_UP;
        } else if (row < ROWS - 1 &&
                bottom < left &&
                bottom < right &&
                bottom < top) {
            direction = DIRECTION_DOWN;
        }

        return direction;
    }

    private void swap(int row1, int col1, int row2, int col2) {

        // inline class definition
        new Thread(new Runnable() {
            @Override
            public void run() {
                Cell temp = new Cell();
                temp.copy(cells[row1][col1]);
                cells[row1][col1].copy(cells[row2][col2]);
                cells[row2][col2].copy(temp);

                int points = 0;
                for(int row = 0; row < ROWS; row++) {
                    points += markChainsAndGetPointsInRow(row);
                }
                for(int col = 0; col < COLS; col++) {
                    points += markChainsAndGetPointsInCol(col);
                }
                repaint(); // now have new colors
                if (points > 0) {
                    game.addToScore(points);
                    removeMarkedChains();
                }
            }
        }).start();
    }




    // over-rides
    private void pause(int milliseconds) {
        try {
            Thread.sleep(milliseconds);
        } catch (InterruptedException e) { }
    }

    public void paintComponent(Graphics g) {
        // background
        g.setColor(Color.BLACK);
        g.fillRect(0,0, WIDTH, HEIGHT);

        // CELLS
        for(int row = 0; row < ROWS; row++) {
            for (int col = 0; col < COLS; col++) {
                int x = col * Cell.SIZE;
                int y = row * Cell.SIZE;
                cells[row][col].draw(g, x, y);
            }
        }
    }

    @Override
    public Dimension getPreferredSize() {
        return new Dimension(WIDTH, HEIGHT);
    }
}
