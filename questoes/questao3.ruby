require 'json'

# Carregar os dados de faturamento do arquivo JSON
begin
  file = File.read('faturamento.json')
  faturamento_diario = JSON.parse(file)
rescue Errno::ENOENT
  puts "Arquivo 'faturamento.json' não encontrado. Verifique o caminho e o nome do arquivo."
  exit
end

# Filtrando apenas os dias com faturamento (ignorando valores zero ou ausentes)
faturamento_valido = faturamento_diario.select { |dia| dia > 0 }

# Verificar se há dias com faturamento válido
if faturamento_valido.any?
  # Calculando o menor, o maior valor e a média
  menor_valor = faturamento_valido.min
  maior_valor = faturamento_valido.max
  media_mensal = faturamento_valido.sum / faturamento_valido.size.to_f

  # Contando os dias em que o faturamento foi superior à média
  dias_acima_da_media = faturamento_valido.count { |dia| dia > media_mensal }

  puts "Menor valor de faturamento: #{menor_valor}"
  puts "Maior valor de faturamento: #{maior_valor}"
  puts "Número de dias com faturamento acima da média: #{dias_acima_da_media}"
else
  puts "Não há faturamento válido registrado para o período."
end
