
N = gets.to_i
A = gets.chomp.split.map(&:to_i)

functionReturn = Array.new()
checkFunctionReturn = Array.new()
pos = 1
answer = 0
difference = 0

def CheckDifference(answer, difference)
  if (difference < 0)
    answer = answer + difference.abs
    [ 0, answer ]
  else
    [ difference, answer ]
  end
end

def FindMIN(pos, a)
  difference = 0
  local_difference = 0
  counter = pos
  while (pos < A.length())
    if (A[pos] <= A[pos - 1])
      local_difference = local_difference + A[pos - 1] - A[pos]
      difference = difference + local_difference
      local_difference = 0
    else
       break
    end
    pos = pos + 1
    counter = pos
  end
  [ difference, counter ]
end

def FindMAX(pos, a)
  difference = 0
  local_difference = 0
  counter = pos
  while (pos < A.length())
    if (A[pos] >= A[pos - 1])
      local_difference = local_difference + A[pos] - A[pos - 1]
      difference = difference + local_difference
      local_difference = 0
    else
      break
    end
    pos = pos + 1
    counter = pos
  end
  [ difference, counter ]
end



while pos < A.length
  if A[pos] == A[pos - 1]
    pos = pos + 1
  elsif A[pos] != A[pos - 1]
    if A[pos] < A[pos - 1]
      functionReturn = FindMIN(pos, A)
      pos = functionReturn[1]
      difference = difference + functionReturn[0]
      answer = answer + functionReturn[0]
    else
      functionReturn = FindMAX(pos, A)
      pos = functionReturn[1]
      difference = difference - functionReturn[0];
    end
  end
    checkFunctionReturn = CheckDifference(answer, difference)
    difference = checkFunctionReturn[0]
    answer = checkFunctionReturn[1]
end
puts answer
