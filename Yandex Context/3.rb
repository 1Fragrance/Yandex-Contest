def sgn(n)
  n <=> 0
end

def mod(n,d)
    result = n % d
    if (sgn(result) * sgn(d) < 0)
       result += d
    end
    result
end

answer = 1
Modul = 7 + 10 ** 9

data = gets.chomp.split.map(&:to_i)
A = gets.chomp.split.map(&:to_i)
A.sort!

leftBorder = 0
rightBorder = A.length - 1
lastElem = A[rightBorder]
lastMinus = lastElem < 0;

if data[1] % 2 == 1
  if lastElem > 0
	  answer *= lastElem
	  rightBorder -= 1
	  data[1] -= 1
  end
end

while data[1] >= 1
  if data[1] == 0
    break;
	elsif data[1] == 1
		answer *= A[rightBorder]
		rightBorder -= 1
		data[1] -= 1
	else
		left = A[leftBorder] * A[leftBorder + 1]
		right = A[rightBorder] * A[rightBorder - 1]
		if left >= right and !lastMinus
			answer *= left
			leftBorder += 2
    elsif (left < right and lastMinus)
      answer *= left
		  leftBorder += 2
    elsif left < right and !lastMinus
      answer *= right
      rightBorder -= 2
    elsif left >= right and lastMinus
      answer *= right
      rightBorder -= 2
		else
			answer *= right
			rightBorder -= 2
		end

    data[1] -= 2
	end
  #mod(answer,Modul)
  answer %= Modul
end
puts answer
